using Lab3.Model;

namespace Lab3.View;

public interface IAppView
{
    int Menu();
    Taskk TaskQuery();
    string TagsQuery();
    void ShowTasks(List<Taskk> toDoList);
    int SaveAndLoadChoice();
}
