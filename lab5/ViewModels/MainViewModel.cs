using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DynamicData;
using NastyaLab5.Database;
using NastyaLab5.Models;
using NastyaLab5.Repository;
using NastyaLab5.Views;
using ReactiveUI;

namespace NastyaLab5.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly ITaskRepository _repository;
    public ObservableCollection<TaskItem> TaskList { get; set; } = [];

    public bool _isSelected;

    public bool IsSelected
    {
        get => _isSelected;
        set => this.RaiseAndSetIfChanged(ref _isSelected, value);
    }

    private TaskItem _selectedTask;

    public TaskItem SelectedTask
    {
        get => _selectedTask;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedTask, value);
            IsSelected = SelectedTask != null;
        }
    }


    public MainViewModel()
    {
        var context = new TaskContext();
        _repository = new TaskRepository(context);
        var t = _repository.LoadFromDb();
        TaskList.AddRange(t);
    }

    public void ShowAddTaskDialog()
    {
        var dialog = new DialogWindow();
        dialog.DataContext = new DialogViewModel(this, dialog);

        dialog.Show();
    }
    
    public void ShowEditTaskDialog()
    {
        var dialog = new DialogWindow();
        dialog.DataContext = new DialogViewModel(this, dialog, SelectedTask);

        dialog.Show();
    }

    public void AddTask(string title, string description, string deadline, string tags)
    {
        var newTask = new TaskItem
        {
            Title = title,
            Description = description,
            Deadline = deadline,
            Tags = tags,
            Id = TaskList.Count + 1
        };
        TaskList.Add(newTask);
        _repository.SaveToDb(TaskList);
        SelectedTask = newTask;
    }

    public void EditTask(string title, string description, string deadline, string tags)
    {
        foreach (var task in TaskList)
        {
            if (task == SelectedTask)
            {
                task.Title = title;
                task.Description = description;
                task.Deadline = deadline;
                task.Tags = tags;
                _repository.SaveToDb(TaskList);
            }
        }
    }
}