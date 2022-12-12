using Beercyclopedia.DataAcess;
using Beercyclopedia.DataAcess.Data;
using Beercyclopedia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Beercyclopedia.Pages.Beers;

public class CreateModel : PageModel
{
    public readonly ApplicationDbContext _db;
    
    public Beer Beer { get; set; }
    public SelectList Brands { get; set; }
    public SelectList Styles { get; set; }

    public CreateModel(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public void OnGet()
    {
        Brands = new SelectList(_db.Brands, nameof(Brand.Id), nameof(Brand.Name));
        Styles = new SelectList(_db.Styles, nameof(Style.Id), nameof(Style.Name));
    }

    public async Task<IActionResult> OnPost(Beer beer)
    {
        if (ModelState.IsValid)
        {
            await _db.Beers.AddAsync(beer);
            await _db.SaveChangesAsync();
            TempData["success"] = "Beer added successfully";
            return RedirectToPage("Index");
        }
        Brands = new SelectList(_db.Brands, nameof(Brand.Id), nameof(Brand.Name));
        Styles = new SelectList(_db.Styles, nameof(Style.Id), nameof(Style.Name));
        return Page();
    }
}