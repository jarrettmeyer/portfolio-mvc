using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    public interface ITaskCreationService
    {
        Task CreateTask(TaskInputModel model);
    }
}