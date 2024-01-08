using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NastyaLab5.Database;
using NastyaLab5.Models;

namespace NastyaLab5.Repository;

public class TaskRepository : ITaskRepository
{
    private readonly TaskContext _context;

    public TaskRepository(TaskContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public void SaveToDb(ObservableCollection<TaskItem> tasks)
    {
        _context.Tasks?.RemoveRange(_context.Tasks);
        _context.SaveChanges();

        // Добавление новых задач и сохранение изменений
        _context.Tasks?.AddRange(tasks);
        _context.SaveChanges();
    }

    public List<TaskItem> LoadFromDb()
    {
        return _context.Tasks!.ToList();
    }
}