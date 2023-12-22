using Lab4.Model;

namespace Lab4.Repository;

public interface IAppRepository
{
    Task Add(Taskk taskk);
    Task<List<Taskk>> SearchByTags(string tags);
    Task<List<Taskk>> LastTasks();
}
