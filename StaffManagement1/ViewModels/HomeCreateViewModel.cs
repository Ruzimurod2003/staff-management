using StaffManagement1.Attributes;
using StaffManagement1.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace StaffManagement1.ViewModels;

public class HomeCreateViewModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    public string? FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email is not valid")]
    [Required]
    public string? Email { get; set; }

    [Required]
    public Departments? Department { get; set; }

    [MaxFileSize(800)]
    [AllowedExtensions(new string[] { ".jpg", ".png" })]
    public IFormFile? Photo { get; set; }

}
