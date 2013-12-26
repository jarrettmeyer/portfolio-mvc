using Portfolio.Lib.DTOs;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Services
{
    public interface ITaskCreationService
    {
        Task CreateTask(TaskDTO taskDto);
    }
}