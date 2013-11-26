using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    public interface ITaskUpdateService
    {
        Task UpdateTask(TaskInputModel model);
    }
}