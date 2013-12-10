using Portfolio.Lib.Models;

namespace Portfolio.Lib.Services
{
    public interface ITaskDeletionService
    {
        Task DeleteTask(int id);
    }
}