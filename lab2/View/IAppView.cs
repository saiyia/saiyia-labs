using Lab2.Model;

namespace Lab2.View;

public interface IAppView
{
    int Menu();
    Taskk TaskQuery();
    List<string> TagsQuery();
    void ShowTasks(List<Taskk> toDoList);
}
