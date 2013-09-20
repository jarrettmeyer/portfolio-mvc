using System.Collections.Generic;
using System.Linq;
using Portfolio.Data;
using Portfolio.Data.Commands;
using Portfolio.Data.Models;
using Portfolio.Domain.ViewModels;

namespace Portfolio.Domain.Services.Impl
{
    public class TaskServiceImpl : ITaskService
    {
        private readonly IRepository repo;
        private readonly ICommandStore commandStore; 

        public TaskServiceImpl(IRepository repo, ICommandStore commandStore)
        {
            this.repo = repo;
            this.commandStore = commandStore;
        }

        public TaskViewModel CreateNewTask(TaskInputModel taskInputModel)
        {
            var task = CreateTaskEntity(taskInputModel);

            var taskViewModel = TaskMapper.Map(task);
            return taskViewModel;
        }

        private Task CreateTaskEntity(TaskInputModel taskInputModel)
        {
            var task = new Task
                       {
                           Description = taskInputModel.Description,
                       };
            var createTaskCommand = commandStore.GetCommand<CreateTask>();
            createTaskCommand.Task = task;
            createTaskCommand.ExecuteCommand();
            return task;
        }

        public IEnumerable<TaskViewModel> GetAllTasks()
        {
            var tasks = repo.All<Task>();
            var taskViewModels = tasks.Select(t => TaskMapper.Map(t));
            return taskViewModels;
        }

    }
}
