using System.ComponentModel.DataAnnotations;

namespace Beercyclopedia.Model;

public class Style
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Please enter a valid style name.")]
    [Display(Name = "Style Name", Prompt = "Beer Style")]
    public string Name { get; set; }
    
}