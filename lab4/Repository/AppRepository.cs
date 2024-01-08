using System.Diagnostics;
using Lab4.Model;
using Lab4.Database;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Repository;

public class AppRepository : IAppRepository
{
    private readonly ApppContext _context;

    public AppRepository(ApppContext context)
    {
        _context = context;
    }


    public Task Add(Taskk taskk)
    {
        if (!_context.Taskks!.Any(t => t.Title == taskk.Title))
        {
            _context.Taskks?.Add(taskk);
            return _context.SaveChangesAsync();
        }

        throw new Exception("Задача уже существует.");
    }

    public Task<List<Taskk>> SearchByTags(string tags)
    {
        // Разбиваем введенные ключевые слова на отдельные части
        string[] tagArr = tags.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Выполняем запрос поиска только по полю Tags
        IQueryable<Taskk> query = _context.Taskks;
        foreach (string tag in tagArr)
        {
            query = query.Where(t => EF.Functions.Like(t.Tags, $"%{tag}%"));
        }

        // Выполняем запрос к базе данных и возвращаем результат
        return query.ToListAsync();
    }

    public Task<List<Taskk>> LastTasks()
    {
        return _context.Taskks!.ToListAsync();
    }
}
