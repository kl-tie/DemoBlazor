namespace DemoBlazor.Models;

public class StudentViewModel
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public DateTime Birthday { get; set; }
}
