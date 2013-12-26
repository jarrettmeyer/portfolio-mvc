using Portfolio.Lib.Models;

namespace Portfolio.Lib.Services
{
    public interface ITaskCreationService
    {
        Task CreateTask(Task model);
    }
}