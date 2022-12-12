using Beercyclopedia.DataAcess.Data;
using Beercyclopedia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beercyclopedia.Pages.Styles;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public Style Style { get; set; }

    public CreateModel(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public void OnGet()
    {
        
    }
    
    public async Task<IActionResult> OnPost(Style style)
    {
        if (ModelState.IsValid)
        {
            await _db.Styles.AddAsync(style);
            await _db.SaveChangesAsync();
            TempData["success"] = "Style added successfully";
            return RedirectToPage("Index");
        }
        return RedirectToPage("Index");
    }
}