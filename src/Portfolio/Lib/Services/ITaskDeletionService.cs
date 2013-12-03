using Portfolio.Models;

namespace Portfolio.Lib.Services
{
    public interface ITaskDeletionService
    {
        Task DeleteTask(int id);
    }
}