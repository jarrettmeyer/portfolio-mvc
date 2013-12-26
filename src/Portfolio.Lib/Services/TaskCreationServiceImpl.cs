using Portfolio.Lib.Data;
using Portfolio.Lib.Models;
using Portfolio.Lib.ViewModels;

namespace Portfolio.Lib.Services
{
    public class TaskCreationServiceImpl : ITaskCreationService
    {
        private readonly IRepository repository;
        private Task task;

        public TaskCreationServiceImpl(IRepository repository)
        {
            this.repository = repository;
        }

        public Task CreateTask(Task model)
        {
            using (var transaction = repository.BeginTransaction())
            {
                UpdateTaskProperties(model);
                AddTagsToTask(model);
                PersistTask(transaction);
                return task;
            }
        }

        private void AddTagsToTask(Task model)
        {
            if (model.Tags == null)
                return;

            foreach (var tagInputModel in model.Tags)
            {
                int id = tagInputModel.Id;
                Tag tag = repository.Load<Tag>(id);
                task.AddTag(tag);                
            }
        }

        private void PersistTask(ITransactionAdapter transaction)
        {
            repository.Add(task);
            transaction.Commit();
        }

        private void UpdateTaskProperties(Task model)
        {
            task = new Task
            {
                Title = model.Title,
                Description = model.Description,
                DueOn = model.DueOn,
                IsCompleted = false,
                CreatedAt = Clock.Instance.Now,
                UpdatedAt = Clock.Instance.Now
            };

        }
    }
}