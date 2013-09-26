﻿using System.Collections.Generic;
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
        private readonly ICommandStore commandStore;
        private readonly IRepository repo;
        private Task task;

        public TaskServiceImpl(IRepository repo, ICommandStore commandStore)
        {
            this.repo = repo;
            this.commandStore = commandStore;
        }

        public TaskViewModel CreateNewTask(TaskInputModel taskInputModel)
        {
            CreateTaskInstance();
            UpdateTaskProperties(taskInputModel);
            ExecuteCreateTaskCommand();
            return TaskMapper.Map(task);
        }

        public IEnumerable<TaskViewModel> GetAllTasks()
        {
            var tasks = repo.All<Task>();
            var taskViewModels = tasks.Select(t => TaskMapper.Map(t));
            return taskViewModels;
        }

        public TaskViewModel UpdateTask(TaskInputModel taskInputModel)
        {
            LoadTaskFromRepository(taskInputModel);
            UpdateTaskProperties(taskInputModel);
            SaveAllChanges();
            return TaskMapper.Map(task);            
        }

        private void ExecuteCreateTaskCommand()
        {
            var createTaskCommand = commandStore.GetCommand<CreateTask>();
            createTaskCommand.Task = task;
            createTaskCommand.ExecuteCommand();
        }

        private void CreateTaskInstance()
        {
            task = new Task();
        }

        private Category GetCategory(TaskInputModel taskInputModel)
        {
            Category category = null;
            if (taskInputModel.Category > 0)
                category = repo.Load<Category>(taskInputModel.Category);
            return category;
        }

        private void LoadTaskFromRepository(TaskInputModel taskInputModel)
        {
            task = repo.Load<Task>(taskInputModel.Id);
        }

        private void SaveAllChanges()
        {
            repo.SaveChanges();
        }

        private void UpdateTaskProperties(TaskInputModel taskInputModel)
        {
            task.Category = GetCategory(taskInputModel);
            task.Description = taskInputModel.Description;
            task.DueOn = taskInputModel.Description.SafeParseDateTime();
        }
    }
}