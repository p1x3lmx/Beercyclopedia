using Beercyclopedia.Data;
using Beercyclopedia.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Beercyclopedia.Pages.Beers;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IEnumerable<Beer> Beers { get; set; }
    public IEnumerable<Brand> Brands { get; set; }

    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
        Beers = _db.Beers.Include(b => b.Brands).Include(b=>b.Styles);

    }
    
}