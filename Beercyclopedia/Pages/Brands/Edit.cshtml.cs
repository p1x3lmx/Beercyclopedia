using Beercyclopedia.Data;
using Beercyclopedia.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beercyclopedia.Pages.Brands;

[BindProperties]
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public Brand Brand { get; set; }

    public EditModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet(int id)
    {
        Brand = _db.Brands.Find(id);
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            _db.Brands.Update(Brand);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }

        return Page();
    }
}
