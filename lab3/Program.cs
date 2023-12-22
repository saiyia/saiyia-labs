using Lab3.Controller;
using Lab3.Model;
using Lab3.Repository;
using Lab3.View;

namespace Lab3;

public static class Program
{
    public static void Main(string[] args)
    {
        var toDoList = new List<Taskk>();
        var appView = new AppView();
        var appRepository = new AppRepository();
        var appController = new AppController(toDoList, appView, appRepository);
        appController.Run();
    }
}
