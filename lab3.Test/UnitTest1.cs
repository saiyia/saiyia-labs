using Lab3.Controller;
using Lab3.Model;
using Lab3.Repository;
using Lab3.View;
using Moq;

namespace Lab3.Test;

public class UnitTest1
{
    [Theory]
    [InlineData("сделать пг", "жесть", "04.04.4040", "уээ аыы ееааа", "аыы")]
    public void SearchByTagsTest(string title, string description, DateTime deadline, string tags, string keytag)
    {
        var toDoList = new List<Taskk>
        {
            new()
            {
                Title = title,
                Description = description,
                Deadline = deadline,
                Tags = tags
            }
        };
        var appView = new AppView();
        var mock = new Mock<IAppRepository>();
        mock.Setup(r => r.DbLoad()).Returns(new List<Taskk>());
        mock.Setup(j => j.JsonLoad()).Returns(new List<Taskk>());
        var appController = new AppController(toDoList, appView, mock.Object);
        
        Assert.Equal(toDoList[0], appController.SearchByTags(keytag)[0]);
    }
    
    [Theory]
    [InlineData("сделать пг", "жесть", "04.04.4040", "уээ аыы ееааа")]
    public void AddWordTest(string title, string description, DateTime deadline, string tags)
    {
        var toDoList = new List<Taskk>();
        var appView = new AppView();
        var mock = new Mock<IAppRepository>();
        mock.Setup(r => r.DbLoad()).Returns(new List<Taskk>());
        mock.Setup(j => j.JsonLoad()).Returns(new List<Taskk>());
        var appController = new AppController(toDoList, appView, mock.Object);
        var expected = new Taskk
        {
            Title = title,
            Description = description,
            Deadline = deadline,
            Tags = tags
        };
        appController.AddTask(expected);
        
        Assert.Equal(expected, toDoList[0]);
    }
}
