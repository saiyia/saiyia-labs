using System.Collections.Generic;
using System.Collections.ObjectModel;
using NastyaLab5.Models;

namespace NastyaLab5.Repository;

public interface ITaskRepository
{
    void SaveToDb(ObservableCollection<TaskItem> tasks);
    List<TaskItem> LoadFromDb();
}
