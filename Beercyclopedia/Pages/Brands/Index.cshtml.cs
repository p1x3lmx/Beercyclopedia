using Beercyclopedia.Data;
using Beercyclopedia.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beercyclopedia.Pages.Brands;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IEnumerable<Brand> Brands;
    public Brand Brand { get; set; }

    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
        Brands = _db.Brands;
    }
    
    public async Task<IActionResult> OnPostDuplicate(int id)
    {
        Brand = _db.Brands.Find(id);
        
        Brand BrandDuplicate = new Brand()
        {
            Name = $"{Brand.Name} Duplicate",
        };
        
        await _db.Brands.AddAsync(BrandDuplicate);
        await _db.SaveChangesAsync();
        TempData["success"] = "Brand duplicated successfully";
        return RedirectToPage("Index");
    }
}