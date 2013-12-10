using Portfolio.Lib.Models;
using Portfolio.Lib.ViewModels;

namespace Portfolio.Lib.Services
{
    public interface ITaskCreationService
    {
        Task CreateTask(TaskInputModel model);
    }
}