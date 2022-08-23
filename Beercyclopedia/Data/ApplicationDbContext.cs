using Beercyclopedia.Model;
using Microsoft.EntityFrameworkCore;

namespace Beercyclopedia.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Beer> Beers { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Style> Styles { get; set; }

}