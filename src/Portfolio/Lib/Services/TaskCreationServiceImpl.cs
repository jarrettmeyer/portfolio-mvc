using System;
using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    public class TaskCreationServiceImpl : ITaskCreationService
    {
        private readonly IRepository repository;

        public TaskCreationServiceImpl(IRepository repository)
        {
            this.repository = repository;
        }

        public Task CreateTask(TaskInputModel model)
        {
            using (var txn = repository.BeginTransaction())
            {
                Task task = new Task
                {
                    Title = model.Title,
                    Description = model.Description,
                    DueOn = model.DueOn.SafeParseDateTime(),
                    IsCompleted = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                repository.Add(task);
                txn.Commit();
                return task;
            }
        }
    }
}