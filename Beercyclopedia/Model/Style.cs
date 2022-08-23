using System.ComponentModel.DataAnnotations;

namespace Beercyclopedia.Model;

public class Style
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
}