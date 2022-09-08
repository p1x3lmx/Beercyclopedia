using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Beercyclopedia.Model;

public class Beer
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Beer name is required.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please select a brand")]
    public int BrandId { get; set; }
    [Required(ErrorMessage = "Please select a Style")]
    public int StyleId { get; set; }
    [Range(1, 5, ErrorMessage = "Rating Value for {0} must be {1} and {2}")]
    public int Rating { get; set; }
    [ValidateNever]
    public Brand Brands { get; set; }
    [ValidateNever]
    public Style Styles { get; set; }
}