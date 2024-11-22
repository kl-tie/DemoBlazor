using System.ComponentModel.DataAnnotations;

namespace DemoBlazor.Models;

public class CreateStudentForm
{
    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;
}
