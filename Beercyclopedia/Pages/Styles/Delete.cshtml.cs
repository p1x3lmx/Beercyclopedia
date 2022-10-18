using Beercyclopedia.Data;
using Beercyclopedia.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Beercyclopedia.Pages.Styles;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _db;
    
    [BindProperty]
    public Style Style { get; set; }
    public bool IsInUse { get; set; }

    public DeleteModel(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public void OnGet(int id)
    {
        var firstFound = _db.Beers.FirstOrDefault((s => s.Styles.Id == id));
        if (firstFound != null)
        {
            IsInUse = true;
            Style = _db.Styles.Find(id);
        }
        Style = _db.Styles.Find(id);
    }

    public async Task<IActionResult> OnPost()
    {
        _db.Styles.Remove(Style);
        await _db.SaveChangesAsync();
        TempData["success"] = "Style deleted successfully";
        return RedirectToPage("Index");

    }

}