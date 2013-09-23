using System;
using System.Collections.Generic;
using System.Linq;
using Portfolio.Common;
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

        public IEnumerable<TaskViewModel> GetAllTasks()
        {
            var tasks = repo.All<Task>();
            var taskViewModels = tasks.Select(t => TaskMapper.Map(t));
            return taskViewModels;
        }

        public TaskViewModel UpdateTask(TaskInputModel taskInputModel)
        {
            var task = repo.Load<Task>(taskInputModel.Id);
            task.Category = GetCategory(taskInputModel);
            task.Description = taskInputModel.Description;
            task.DueOn = taskInputModel.Description.SafeParseDateTime();
            return TaskMapper.Map(task);            
        }

        private Task CreateTaskEntity(TaskInputModel taskInputModel)
        {
            var task = new Task
            {
                Category = GetCategory(taskInputModel),
                Description = taskInputModel.Description,
                DueOn = taskInputModel.DueOn.SafeParseDateTime()
            };
            var createTaskCommand = commandStore.GetCommand<CreateTask>();
            createTaskCommand.Task = task;
            createTaskCommand.ExecuteCommand();
            return task;
        }

        private Category GetCategory(TaskInputModel taskInputModel)
        {
            Category category = null;
            if (taskInputModel.Category > 0)
                category = repo.Load<Category>(taskInputModel.Category);
            return category;
        }
    }
}
