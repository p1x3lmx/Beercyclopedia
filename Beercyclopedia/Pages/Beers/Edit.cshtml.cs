using Beercyclopedia.DataAcess.Data;
using Beercyclopedia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Beercyclopedia.Pages.Beers;


public class EditModel : PageModel
{
    private readonly ApplicationDbContext _db;
    [BindProperty]
    public Beer Beer { get; set; }
    public SelectList Brands { get; set; }
    public SelectList Styles  { get; set; }

    public EditModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet(int id)
    {
        Beer = _db.Beers.Find(id);
        Styles = new SelectList(_db.Styles, nameof(Style.Id), nameof(Style.Name));
        Brands = new SelectList(_db.Brands, nameof(Brand.Id), nameof(Brand.Name));
    }  
    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            _db.Beers.Update(Beer);
            await _db.SaveChangesAsync();
            TempData["success"] = "Beer edited successfully";
            return RedirectToPage("Index");
        }
        Styles = new SelectList(_db.Styles, nameof(Style.Id), nameof(Style.Name));
        Brands = new SelectList(_db.Brands, nameof(Brand.Id), nameof(Brand.Name));
        return Page();
    }
}