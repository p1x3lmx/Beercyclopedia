using Beercyclopedia.Data;
using Beercyclopedia.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Beercyclopedia.Pages.Beers;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IList<Beer> Beers { get; set; }
    public IQueryable<Brand> Brands { get; set; }

    public string IdSort { get; set; }
    public string BrandSort { get; set; }
    public string StyleSort { get; set; }
    public string RatingSort { get; set; }
    public string CurrentSort { get; set; }
    public Beer Beer { get; set; }
    public string Message { get; set; }

    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }
    
    /*public void OnGet()
    {
        Beers = _db.Beers.Include(b => b.Brands).Include(b=>b.Styles);
    }*/

    public async Task OnGetAsync(string sortOrder)
    {
        IdSort = String.IsNullOrEmpty(sortOrder) ? "id_desc": "";
        BrandSort = sortOrder == "Brand" ? "brand_desc" : "Brand";
        StyleSort = sortOrder == "Style" ? "style_desc" : "Style";
        RatingSort = sortOrder == "Rating" ? "rating_desc" : "Rating";
        IQueryable<Beer> beerIQ = from s in _db.Beers select s;

        switch (sortOrder)
        {
            case "id_desc":
                beerIQ = beerIQ.OrderByDescending(s => s.Id);
                break;
            case "Rating":
                beerIQ = beerIQ.OrderBy(s => s.Rating);
                break;
            case "rating_desc":
                beerIQ = beerIQ.OrderByDescending(s => s.Rating);
                break;
            case "Brand":
                beerIQ = beerIQ.OrderBy(s => s.Brands.Name);
                break;
            case "brand_desc":
                beerIQ = beerIQ.OrderByDescending(s => s.Brands.Name);
                break;
            case "Style":
                beerIQ = beerIQ.OrderBy(s => s.Styles.Name);
                break;
            case "style_desc":
                beerIQ = beerIQ.OrderByDescending(s => s.Styles.Name);
                break;
            default:
                beerIQ = beerIQ.OrderBy(s => s.Id);
                break;
        }

        Beers = await beerIQ.Include(b => b.Brands).Include(b => b.Styles).AsNoTracking().ToListAsync();
    }

    public async Task<IActionResult> OnPostDuplicate(int id)
    {
        Beer = _db.Beers.Find(id);
        
        Beer BeerDuplicate = new Beer()
        {
            Name = $"{Beer.Name} Duplicate",
            BrandId = Beer.BrandId,
            StyleId = Beer.StyleId,
            Rating = Beer.Rating,
            IBU = Beer.IBU,
            Description = Beer.Description
        };
        await _db.Beers.AddAsync(BeerDuplicate);
        await _db.SaveChangesAsync();
        return RedirectToPage("Index");
    }
    
}