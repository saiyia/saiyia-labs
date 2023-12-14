using Lab3.Model;
using Lab3.Database;
using Newtonsoft.Json;

namespace Lab3.Repository;

public class AppRepository : IAppRepository
{
    private readonly string _jsonFilePath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "tasks.json");

    private readonly ApppContext _context = new ();

    public AppRepository()
    {
        _context.Database.EnsureCreated();
    }
    public void DbSave(List<Taskk> taskks)
    {
        _context.Tasks?.RemoveRange(_context.Tasks);
        _context.SaveChanges();

        // Добавление новых задач и сохранение изменений
        _context.Tasks?.AddRange(taskks);
        _context.SaveChanges();
    }

    public List<Taskk> DbLoad()
    {
        return _context.Tasks!.ToList();
    }

    public void JsonSave(List<Taskk> taskks)
    {
        var jsonData = JsonConvert.SerializeObject(taskks, Formatting.Indented);
        File.WriteAllText(_jsonFilePath, jsonData);
    }

    public List<Taskk> JsonLoad()
    {
        var temp = new List<Taskk>();
        File.Create(_jsonFilePath).Close();

        var jsonData = File.ReadAllText(_jsonFilePath);
        var data = JsonConvert.DeserializeObject<List<Taskk>>(jsonData) ??
                   new List<Taskk>();
        foreach (var taskk in data)
        {
            temp.Add(new Taskk
            {
                Title = taskk.Title,
                Description = taskk.Description,
                Deadline = taskk.Deadline,
                Tags = taskk.Tags
            });
        }

        return temp;
    }
}
