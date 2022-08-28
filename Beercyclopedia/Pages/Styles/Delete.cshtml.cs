using Beercyclopedia.Data;
using Beercyclopedia.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Beercyclopedia.Pages.Styles;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _db;
    
    public Style Style { get; set; }
    public int isInuse;

    public DeleteModel(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public void OnGet(int id)
    {
        Style = _db.Styles.Find(id);

    }
}