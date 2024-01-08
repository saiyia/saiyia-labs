using Lab4.Model;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Database;

public class ApppContext:DbContext
{
    public DbSet<Taskk>? Taskks { get; set; }
    
    public ApppContext(DbContextOptions<ApppContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
