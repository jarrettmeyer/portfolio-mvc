using Portfolio.Models;

namespace Portfolio.Lib.Services
{
    public interface ITaskCompletionService
    {
        Task CompleteTask(int id);
    }
}