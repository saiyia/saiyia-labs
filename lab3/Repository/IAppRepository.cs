using Lab3.Model;

namespace Lab3.Repository;

public interface IAppRepository
{
    void DbSave(List<Taskk> taskks);
    List<Taskk> DbLoad();
    void JsonSave(List<Taskk> taskks);
    List<Taskk> JsonLoad();
}
