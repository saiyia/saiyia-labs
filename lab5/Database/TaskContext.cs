using Microsoft.EntityFrameworkCore;
using NastyaLab5.Models;

namespace NastyaLab5.Database;

public class TaskContext:DbContext
{
    public DbSet<TaskItem>? Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ToDoList.db");
    }
}
