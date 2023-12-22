using Lab4.Model;

namespace Lab4.Services;

public interface IStoreTask
{
    Taskk SetTaskk(string title, string description, DateTime dateTime, string tags);
}
