using Lab4.Model;

namespace Lab4.Services;

public class Validation : IValidation
{
    public void ValidateTask(Taskk taskk)
    {
        if (taskk.Title=="" || taskk.Description=="" || taskk.Deadline.ToString() == "" ||
            taskk.Tags=="")
            throw new Exception("Empty fields are not allowed");
    }
}
