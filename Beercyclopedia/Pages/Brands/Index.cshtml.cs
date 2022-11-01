using Beercyclopedia.Data;
using Beercyclopedia.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Beercyclopedia.Pages.Brands;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IEnumerable<Brand> Brands;
    public Brand Brand { get; set; }
    public String BrandSort { get; set; }

    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task OnGetAsync(string sortOrder)
    {
        BrandSort = String.IsNullOrEmpty(sortOrder) ? "brand_desc" : "";
        IQueryable<Brand> brandIQ = from s in _db.Brands select s;

        switch (sortOrder)
        {
            case "brand_desc":
                brandIQ = brandIQ.OrderByDescending(s => s.Name);
                break;
            default:
                brandIQ = brandIQ.OrderBy(s => s.Name);
                break;
        }

        Brands = await brandIQ.AsNoTracking().ToListAsync();
    }

    public async Task<IActionResult> OnPostDuplicate(int id)
    {
        Brand = _db.Brands.Find(id);

        Brand BrandDuplicate = new Brand() {Name = $"{Brand.Name} Duplicate",};

        await _db.Brands.AddAsync(BrandDuplicate);
        await _db.SaveChangesAsync();
        TempData["success"] = "Brand duplicated successfully";
        return RedirectToPage("Index");
    }
}