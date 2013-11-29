using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

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

        public Task CreateTask(TaskInputModel model)
        {
            using (var transaction = repository.BeginTransaction())
            {
                UpdateTaskProperties(model);
                AddTagsToTask(model);
                PersistTask(transaction);
                return task;
            }
        }

        private void AddTagsToTask(TaskInputModel model)
        {
            if (model.Tags == null)
                return;

            foreach (var tagInputModel in model.Tags)
            {
                string id = tagInputModel.Id;
                Tag tag = repository.Load<Tag>(id);
                task.Tags.Add(tag);
            }
        }

        private void PersistTask(ITransactionAdapter transaction)
        {
            repository.Add(task);
            transaction.Commit();
        }

        private void UpdateTaskProperties(TaskInputModel model)
        {
            task = new Task
            {
                Title = model.Title,
                Description = model.Description,
                DueOn = model.DueOn.SafeParseDateTime(),
                IsCompleted = false,
                CreatedAt = Clock.Instance.Now,
                UpdatedAt = Clock.Instance.Now
            };

        }
    }
}