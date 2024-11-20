using DemoBlazor.Entities;
using DemoBlazor.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace DemoBlazor.Components.Pages;

public partial class Students : ComponentBase
{
    [Inject]
    private IDbContextFactory<DemoDbContext> DbFactory { get; set; } = default!;

    public List<StudentViewModel> StudentList { get; set; } = [];

    protected override async Task OnInitializedAsync()
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

        await base.OnInitializedAsync();
    }
}
