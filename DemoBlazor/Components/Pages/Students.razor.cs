using DemoBlazor.Entities;
using DemoBlazor.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace DemoBlazor.Components.Pages;

public partial class Students : ComponentBase
{
    [Inject]
    private IDbContextFactory<DemoDbContext> DbFactory { get; set; } = default!;

    public List<StudentViewModel> StudentList { get; set; } = [];

    [SupplyParameterFromForm]
    public CreateStudentForm Form { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        await ReloadDataGridAsync();

        await base.OnInitializedAsync();
    }

    private async Task ReloadDataGridAsync()
    {
        var db = await DbFactory.CreateDbContextAsync();

        StudentList = await db.Students
            .Select(Q => new StudentViewModel
            {
                Id = Q.Id,
                FullName = Q.FirstName + " " + Q.LastName,
                Birthday = Q.Birthday
            })
            .ToListAsync();
    }

    private async Task OnSubmitAsync(EditContext context)
    {
        var db = await DbFactory.CreateDbContextAsync();

        db.Students.Add(new Student
        {
            Id = Guid.NewGuid(),
            FirstName = Form.FirstName,
            LastName = Form.LastName,
            Birthday = DateTime.UtcNow
        });

        await db.SaveChangesAsync();

        await ReloadDataGridAsync();
    }
}
