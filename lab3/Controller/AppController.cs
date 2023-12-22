using Lab3.Model;
using Lab3.Repository;
using Lab3.View;

namespace Lab3.Controller;

public class AppController
{
    private List<Taskk> _toDoList;
    private readonly IAppView _appView;
    private readonly IAppRepository _appRepository;

    public AppController(List<Taskk> toDoList, IAppView appView, IAppRepository appRepository)
    {
        _toDoList = toDoList;
        _appView = appView;
        _appRepository = appRepository;
    }

    public void AddTask(Taskk task) // добавление книги
    {
        _toDoList.Add(task);
    }

    public List<Taskk> SearchByTags(string tags) // Реалиaзация поиска по ключевым словам
    {
        var tagList = tags.Split(' ').ToList();
        var temp = new List<Taskk>();
        foreach (var task in _toDoList)
        {
            foreach (var tag in tagList)
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
        var mode = _appView.SaveAndLoadChoice();

        switch (mode)
        {
            case 1:
                _toDoList = _appRepository.DbLoad();
                break;
            case 2:
                _toDoList = _appRepository.JsonLoad();
                break;
        }
        
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

        switch (mode)
        {
            case 1:
                _appRepository.DbSave(_toDoList);
                break;
            case 2:
                _appRepository.JsonSave(_toDoList);
                break;
        }
    }
}
