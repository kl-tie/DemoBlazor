using Microsoft.EntityFrameworkCore;

namespace DemoBlazor.Entities;

public partial class DemoDbContext : DbContext
{
    public DbSet<Student> Students { get; set; } = null!;

    public DemoDbContext(DbContextOptions<DemoDbContext> options)
        : base(options)
    {
    }
}
