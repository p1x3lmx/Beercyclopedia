using System.ComponentModel.DataAnnotations;

namespace Beercyclopedia.Model;

public class Brand
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Please enter a valid beer brand name.")]
    [Display(Name = "Brewery Brand", Prompt = "Beer Brand")]
    public string Name { get; set; }
    
}