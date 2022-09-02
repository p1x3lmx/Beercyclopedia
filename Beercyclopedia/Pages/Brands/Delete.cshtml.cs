using Beercyclopedia.Data;
using Beercyclopedia.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beercyclopedia.Pages.Brands;

public class DeleteModel : PageModel
{
    public readonly ApplicationDbContext _db;
    [BindProperty] 
    public Brand Brand { get; set; }

    public bool IsInUse { get; set; }

    public DeleteModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet(int id)
    {
        var firstFound = _db.Beers.FirstOrDefault((s => s.Brands.Id == id));
        if (firstFound != null)
        {
            IsInUse = true;
            Brand = _db.Brands.Find(id);
        }
        Brand = _db.Brands.Find(id);
    }
    
    public async Task<IActionResult> OnPost()
    {
        _db.Brands.Remove(Brand);
        await _db.SaveChangesAsync();
        return RedirectToPage("Index");

    }
        
}