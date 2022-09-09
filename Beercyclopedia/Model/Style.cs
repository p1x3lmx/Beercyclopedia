using System.ComponentModel.DataAnnotations;

namespace Beercyclopedia.Model;

public class Style
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Please enter a valid style name.")]
    public string Name { get; set; }
    
}