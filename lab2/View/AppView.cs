using Lab2.Model;

namespace Lab2.View;

public class AppView : IAppView
{
    public int Menu() // Взаимодействие с пользователем для выбора пунктов меню
    {
        Console.WriteLine(
            "Menu:\n1. Add Task.\n2. Search Task.\n3. Last Tasks.\n4. Exit.");
        Console.Write("> ");
        var isValid = int.TryParse(Console.ReadLine(), out var n);
        if (!isValid || n < 1 || n > 3)
            throw new Exception("Введено неверное значение");
        return n;
    }

    public Taskk TaskQuery()
    {
        var toDoList = new Taskk();
        var tempList = new List<string>();

        Console.WriteLine("New Task");
        Console.WriteLine("Title: ");
        var input = Console.ReadLine() ?? "";
        if (input == "")
            throw new Exception("An empty string is not allowed.");
        toDoList.Title = input;

        Console.WriteLine("Description: ");
        input = Console.ReadLine() ?? "";
        if (input == "")
            throw new Exception("An empty string is not allowed.");
        toDoList.Description = input;

        Console.WriteLine("Deadline: ");
        input = Console.ReadLine() ?? "";
        toDoList.Deadline = Convert.ToDateTime(input);

        while (true)
        {
            Console.WriteLine("Tags (finish on empty line): ");
            input = Console.ReadLine() ?? "";
            if (input == "")
                break;
            tempList.Add(input);
        }

        if (!tempList.Any())
            throw new Exception("An empty string is not allowed.");
        toDoList.Tags = tempList;

        return toDoList;
    }

    public List<string> TagsQuery()
    {
        Console.WriteLine("Search tasks by tag :");
        var input = Console.ReadLine() ?? "";
        var tags = input.Split(' ').ToList();
        return tags;
    }

    public void ShowTasks(List<Taskk> toDoList)
    {
        if (toDoList.Count > 0)
        {
            foreach (var task in toDoList)
            {
                Console.WriteLine("Title: " + task.Title);
                Console.WriteLine("Description: " + task.Description);
                Console.WriteLine("Deadline: " + task.Deadline);
                Console.WriteLine("Tags:");
                foreach (var tag in task.Tags)
                {
                    Console.Write(" " + tag);
                }
                Console.WriteLine();
            }
        }
        else
            Console.WriteLine("No such tasks.");    
    }
    
}
