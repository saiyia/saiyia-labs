using System;
using System.Reactive;
using Avalonia.Controls;
using NastyaLab5.Models;
using NastyaLab5.Views;
using ReactiveUI;

namespace NastyaLab5.ViewModels;

public class DialogViewModel : ViewModelBase
{
    private string _title;
    private string _description;
    private string _deadline;
    private string _tags;
    private int _mode;

    private MainViewModel _mainViewModel;
    private DialogWindow _dialog;
    private TaskItem _taskItem;

    public DialogViewModel(MainViewModel main, DialogWindow dialog)
    {
        _mainViewModel = main;
        _dialog = dialog;
        _mode = 0;
    }

    public DialogViewModel(MainViewModel main, DialogWindow dialog, TaskItem taskItem)
    {
        _mainViewModel = main;
        _dialog = dialog;
        _taskItem = taskItem;
        Title = taskItem.Title;
        Description = taskItem.Description;
        Deadline = taskItem.Deadline;
        Tags = taskItem.Tags;
        Mode = 1;
    }


    public int Mode
    {
        get => _mode;
        set => this.RaiseAndSetIfChanged(ref _mode, value);
    }

    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }

    public string Deadline
    {
        get => _deadline;
        set => this.RaiseAndSetIfChanged(ref _deadline, value);
    }

    public string Tags
    {
        get => _tags;
        set => this.RaiseAndSetIfChanged(ref _tags, value);
    }

    public void ConfirmAction()
    {
        switch (Mode)
        {
            case 0:
                _mainViewModel.AddTask(Title, Description, Deadline, Tags);
                break;
            case 1:
                _mainViewModel.EditTask(Title, Description, Deadline, Tags);
                break;
        }

        _dialog.Close();
    }
    
}
