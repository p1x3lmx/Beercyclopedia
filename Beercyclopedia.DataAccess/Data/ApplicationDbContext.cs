using Beercyclopedia.Models;
using Microsoft.EntityFrameworkCore;

namespace Beercyclopedia.DataAcess.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Beer> Beers { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Style> Styles { get; set; }

}