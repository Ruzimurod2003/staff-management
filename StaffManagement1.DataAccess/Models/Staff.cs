using System.ComponentModel.DataAnnotations;

namespace StaffManagement1.Models;

public class Staff
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    public string? FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    [Display(Name ="Last Name")]
    public string? LastName { get; set; }

    [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email is not valid")]
    [Required]
    public string? Email { get; set; }

    [Required]
    public Departments? Department { get; set; }

    public string? PhotoFilePath { get; set; }
}

public enum Departments
{
    None,
    Administrator,
    RnD,
    Operator,
    Production
}
