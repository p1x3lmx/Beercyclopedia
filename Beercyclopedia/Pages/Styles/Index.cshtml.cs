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

    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet()
    {
        Styles = _db.Styles;
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