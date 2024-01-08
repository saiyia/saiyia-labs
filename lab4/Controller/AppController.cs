using Lab4.Model;
using Lab4.Repository;
using Lab4.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controller;

public class AppController
{
    private readonly IAppRepository _appRepository;

    public AppController(IAppRepository appRepository)
    {
        _appRepository = appRepository;
    }

    [HttpPost]
    [Route("/add-task")]
    public Task Add([FromBody] string fake, string title, string description, DateTime deadline, string tags)
    {
        var validator = new Validation();
        var storeTask = new StoreTask(validator);
        var task = storeTask.SetTaskk(title, description, deadline, tags);

        return _appRepository.Add(task);
    }

    [HttpGet]
    [Route("/search-tasks-by-tags")]
    public Task<List<Taskk>> SearchTasks(string tags)
    {
        return _appRepository.SearchByTags(tags);
    }

    [HttpGet]
    [Route("/last-tasks")]
    public Task<List<Taskk>> LastTasks()
    {
        return _appRepository.LastTasks();
    }
}
