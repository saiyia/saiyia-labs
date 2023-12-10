using Lab2.Model;
using Lab2.View;

namespace Lab2.Controller;

public class AppController
{
    private readonly List<Taskk> _toDoList;
    private readonly IAppView _appView;

    public AppController(List<Taskk> toDoList, IAppView appView)
    {
        _toDoList = toDoList;
        _appView = appView;
    }

    private void AddTask(Taskk task) // добавление книги
    {
        _toDoList.Add(task);
    }

    public List<Taskk> SearchByTags(List<string> tags) // Реалиaзация поиска по ключевым словам
    {
        var temp = new List<Taskk>();
        foreach (var task in _toDoList)
        {
            foreach (var tag in tags)
            {
                if (task.Tags.Contains(tag))
                {
                    temp.Add(task);
                    break;
                }
            }
        }

        return temp;
    }

    public List<Taskk> LastTasks()
    {
        return _toDoList.OrderBy(t => t.Deadline).ToList();
    }

    public void Run()
    {
        var running = true;
        while (running)
        {
            var menu = _appView.Menu();
            switch (menu)
            {
                case 1:
                    AddTask(_appView.TaskQuery());
                    break;
                case 2:
                    _appView.ShowTasks(SearchByTags(_appView.TagsQuery()));
                    break;
                case 3:
                    _appView.ShowTasks(LastTasks());
                    break;
                case 4:
                    running = !running;
                    break;
            }
        }
    }
}
