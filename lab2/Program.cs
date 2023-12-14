using Lab2.Controller;
using Lab2.Model;
using Lab2.View;

namespace Lab2;

public static class Program
{
    public static void Main(string[] args)
    {
        var toDoList = new List<Taskk>();
        var appView = new AppView();
        var appController = new AppController(toDoList, appView);
        appController.Run();
    }
}
