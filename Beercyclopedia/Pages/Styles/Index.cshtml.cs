using Beercyclopedia.Data;
using Beercyclopedia.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Beercyclopedia.Pages.Styles;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IEnumerable<Style> Styles;

    public Style Style { get; set; }
    public String StyleSort { get; set; }
    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }

    // public void OnGet()
    // {
    //     Styles = _db.Styles;
    // }

    public async Task OnGetAsync(string sortOrder)
    {
        StyleSort = String.IsNullOrEmpty(sortOrder) ? "style_desc" : "";
        IQueryable<Style> styleIQ = from s in _db.Styles select s;

        switch (sortOrder)
        {
            case "style_desc":
                styleIQ = styleIQ.OrderByDescending(s => s.Name);
                break;
            default:
                styleIQ = styleIQ.OrderBy(s => s.Name);
                break;
        }

        Styles = await styleIQ.AsNoTracking().ToListAsync();

    }
    
    
    public async Task<IActionResult> OnPostDuplicate(int id)
    {
        Style = _db.Styles.Find(id);
        
        Style StyleDuplicate = new Style()
        {
            Name = $"{Style.Name} Duplicate",
        };
        await _db.Styles.AddAsync(StyleDuplicate);
        await _db.SaveChangesAsync();
        TempData["success"] = "Style duplicated successfully";
        return RedirectToPage("Index");
    }
}