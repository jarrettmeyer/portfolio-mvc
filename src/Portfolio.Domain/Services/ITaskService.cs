using System.Collections.Generic;
using Portfolio.Domain.ViewModels;

namespace Portfolio.Domain.Services
{
    public interface ITaskService
    {
        TaskViewModel CreateNewTask(TaskInputModel taskInputModel);

        IEnumerable<TaskViewModel> GetAllTasks();
    }
}
