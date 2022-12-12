using Beercyclopedia.DataAcess.Data;
using Beercyclopedia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beercyclopedia.Pages.Styles;

[BindProperties]
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public Style Style { get; set; }

    public EditModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet(int id)
    {
        Style = _db.Styles.Find(id);
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            _db.Styles.Update(Style);
            await _db.SaveChangesAsync();
            TempData["success"] = "Style updated successfully";
            return RedirectToPage("Index");
        }
        return Page();
    }
    
    
}