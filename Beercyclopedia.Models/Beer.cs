using System.ComponentModel.DataAnnotations;
using Beercyclopedia.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Beercyclopedia.Models;

public class Beer
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Beer name is required.")]
    [Display(Name = "Beer Name", Prompt = "Enter Beer Name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please select a brand")]
    [Display(Name = "Beer Brand",Prompt = "Enter Beer Brand")]
    public int BrandId { get; set; }
    [Required(ErrorMessage = "Please select a Style")]
    [Display(Name = "Style",Prompt = "BCJP Style")]
    public int StyleId { get; set; }
    [Range(1, 5, ErrorMessage = "Rating Value for {0} must be {1} and {2}")]
    [Display(Name = "Beer Rating", Prompt = "Enter Beer Rating")]
    public int Rating { get; set; }
    [Range(0, 200, ErrorMessage = "IBU Value should be between {1} and {2}")]
    [Display(Name = "IBU", Prompt = "Beer IBU")]
    public int IBU { get; set; }
    public string Description { get; set; }
    [ValidateNever]
    [Display(Prompt = "Select Beer Brand")]
    public Brand Brands { get; set; }
    [ValidateNever]
    public Style Styles { get; set; }
}