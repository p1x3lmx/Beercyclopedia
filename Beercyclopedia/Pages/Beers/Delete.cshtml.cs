using Beercyclopedia.Data;
using Beercyclopedia.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Beercyclopedia.Pages.Beers;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _db;
    [BindProperty] public Beer Beer { get; set; }

    public DeleteModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet(int id)
    {
        Beer = _db.Beers.Find(id);
    }

    public async Task<IActionResult> OnPost()
    {
        var beerFromDb = _db.Beers.Find(Beer.Id);
        if (beerFromDb != null)
        {
            _db.Beers.Remove(beerFromDb);
            await _db.SaveChangesAsync();
            TempData["success"] = "Beer deleted successfully";
            return RedirectToPage("Index");
        }
        return Page();
    }
}