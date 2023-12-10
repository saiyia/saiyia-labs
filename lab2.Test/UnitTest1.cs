using Lab2.Model;
using Lab2.View;
using Lab2.Controller;

namespace Lab2.Test;

public class UnitTest1
{
    [Fact]
    public void SearchByTagsTest()
    {
        var toDoList = new List<Taskk>
        {
            new()
            {
                Title = "сделать проекционку",
                Description = "помогите",
                Deadline = new DateTime(2023, 12, 26),
                Tags = new List<string> { "начать", "закончить" }
            },
            new()
            {
                Title = "сдать сишарп",
                Description = "дай бог",
                Deadline = new DateTime(2023, 12, 30),
                Tags = new List<string> { "2 лаба", "3 лаба", "4 лаба", "5 лаба" }
            }
        };

        var appView = new AppView();
        var appController = new AppController(toDoList, appView);
        var actual = appController.SearchByTags(new List<string> { "2 лаба", "3 лаба" });
        Assert.Equal(actual[0], toDoList[1]);
    }

    [Fact]
    public void LastTasksTest()
    {
        var toDoList = new List<Taskk>
        {
            new()
            {
                Title = "сделать проекционку",
                Description = "помогите",
                Deadline = new DateTime(2023, 12, 26),
                Tags = new List<string> { "начать", "закончить" }
            },
            new()
            {
                Title = "сдать сишарп",
                Description = "дай бог",
                Deadline = new DateTime(2023, 12, 30),
                Tags = new List<string> { "2 лаба", "3 лаба", "4 лаба", "5 лаба" }
            }
        };

        var appView = new AppView();
        var appController = new AppController(toDoList, appView);
        var actual = appController.LastTasks();
        Assert.Equal(actual, toDoList);
    }
}
