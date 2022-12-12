using Beercyclopedia.DataAcess.Data;
using Beercyclopedia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Beercyclopedia.Pages.Beers;

public class DetailModel : PageModel
{
    
    private readonly ApplicationDbContext _db;
    public Beer Beer { get; set; }
    public Style Style { get; set; }
    public Brand Brand { get; set; }

    public DetailModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet(int id)
    {
        Beer = _db.Beers.Find(id);
        Style = _db.Styles.Find(Beer.StyleId);
        Brand = _db.Brands.Find(Beer.BrandId);
    } 
    
}