using Beercyclopedia.Data;
using Beercyclopedia.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Beercyclopedia.Pages.Beers;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IEnumerable<Beer> Beers { get; set; }
    public IEnumerable<Brand> Brands { get; set; }
    public Beer Beer { get; set; }
    public string Message { get; set; }

    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public void OnGet()
    {
        Beers = _db.Beers.Include(b => b.Brands).Include(b=>b.Styles);
    }

    public async Task<IActionResult> OnPostDuplicate(int id)
    {
        Beer = _db.Beers.Find(id);
        
        Beer BeerDuplicate = new Beer()
        {
            Name = Beer.Name,
            BrandId = Beer.BrandId,
            StyleId = Beer.StyleId,
            Rating = Beer.Rating
        };
        await _db.Beers.AddAsync(BeerDuplicate);
        await _db.SaveChangesAsync();
        return RedirectToPage("Index");
    }
    
}