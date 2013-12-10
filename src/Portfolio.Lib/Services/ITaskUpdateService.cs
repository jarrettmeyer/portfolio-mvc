using Portfolio.Lib.Models;
using Portfolio.Lib.ViewModels;

namespace Portfolio.Lib.Services
{
    public interface ITaskUpdateService
    {
        Task UpdateTask(TaskInputModel model);
    }
}