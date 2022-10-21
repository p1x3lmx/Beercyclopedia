using Beercyclopedia.Data;
using Beercyclopedia.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Beercyclopedia.Pages.Beers;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public Beer Beer { get; set; }

    public DeleteModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet(int id)
    {
        Beer = _db.Beers.Find(id);
    }
    
    public async Task<IActionResult> OnPost(Beer beer)
    {
        _db.Beers.Remove(beer);
        await _db.SaveChangesAsync();
        TempData["success"] = "Beer deleted successfully";
        return RedirectToPage("Index");
    }
    
}