using Lab4.Model;

namespace Lab4.Services;

public class StoreTask : IStoreTask
{
    private readonly IValidation _validator;
    public StoreTask(IValidation validator)
    {
        _validator = validator;
    }
    
    public Taskk SetTaskk(string title, string description, DateTime deadline, string tags)
    {
        var taskk = new Taskk{Title = title, Description = description, Deadline = deadline, Tags = tags};

        _validator.ValidateTask(taskk);
        return taskk;

    }
}
