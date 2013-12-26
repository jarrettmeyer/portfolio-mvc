using Portfolio.Lib.DTOs;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Services
{
    public interface ITaskUpdateService
    {
        Task UpdateTask(TaskDTO taskDto);
    }
}