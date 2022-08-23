using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Beercyclopedia.Model;

public class Beer
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int BrandId { get; set; }
    [Required]
    public int StyleId { get; set; }
    [ValidateNever]
    public Brand Brands { get; set; }
    [ValidateNever]
    public Style Styles { get; set; }
}