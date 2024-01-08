using System.ComponentModel.DataAnnotations;
using ReactiveUI;

namespace NastyaLab5.Models;

public class TaskItem:ReactiveObject
{
    [Key]
    public int Id { get; set; }
    
    
    private string _title;
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }
    
    private string _description;
    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }
    
    private string _deadline;
    public string Deadline
    {
        get => _deadline;
        set => this.RaiseAndSetIfChanged(ref _deadline, value);
    }
    
    private string _tags;
    public string Tags
    {
        get => _tags;
        set => this.RaiseAndSetIfChanged(ref _tags, value);
    }
}
