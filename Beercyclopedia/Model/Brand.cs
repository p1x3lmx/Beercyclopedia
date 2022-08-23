using System.ComponentModel.DataAnnotations;

namespace Beercyclopedia.Model;

public class Brand
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    
}