using Lab3.Model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Database;

public class ApppContext:DbContext
{
    public DbSet<Taskk>? Tasks { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ToDoList.db");
    }
}
