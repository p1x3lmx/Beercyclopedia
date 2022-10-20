using Beercyclopedia.Data;
using Beercyclopedia.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beercyclopedia.Pages.Brands;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public Brand Brand { get; set; }

    public CreateModel(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public void OnGet()
    {
        
    }
    
    public async Task<IActionResult> OnPost(Brand brand)
    {
        if (ModelState.IsValid)
        {
            await _db.Brands.AddAsync(brand);
            await _db.SaveChangesAsync();
            TempData["success"] = "Brand added successfully";
            return RedirectToPage("Index");
        }

        return Page();
    }
}