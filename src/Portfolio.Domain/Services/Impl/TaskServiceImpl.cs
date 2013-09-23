using System;
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
            // Get the category
            Category category = null;
            if (taskInputModel.Category > 0)
                category = repo.Load<Category>(taskInputModel.Category);

            // Get the due date.
            DateTime dueOn;
            bool hasDueDate = DateTime.TryParse(taskInputModel.DueOn, out dueOn);

            var task = new Task
                       {
                           Category = category,
                           Description = taskInputModel.Description,
                           DueOn = (hasDueDate) ? dueOn : (DateTime?)null
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
