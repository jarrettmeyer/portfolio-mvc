using Portfolio.Lib.Data;
using Portfolio.Lib.DTOs;
using Portfolio.Lib.Models;

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

        public Task CreateTask(TaskDTO taskDto)
        {
            using (var transaction = repository.BeginTransaction())
            {
                UpdateTaskProperties(taskDto);
                AddTagsToTask(taskDto);
                PersistTask(transaction);
                return task;
            }
        }

        private void AddTagsToTask(TaskDTO taskDto)
        {
            if (taskDto.Tags == null)
                return;

            foreach (TagDTO tagDto in taskDto.Tags)
            {
                int id = tagDto.Id;
                Tag tag = repository.Load<Tag>(id);
                task.AddTag(tag);                
            }
        }

        private void PersistTask(ITransactionAdapter transaction)
        {
            repository.Add(task);
            transaction.Commit();
        }

        private void UpdateTaskProperties(TaskDTO taskDto)
        {
            task = repository.Load<Task>(taskDto.Id);
            task.Title = taskDto.Title;
            task.Description = taskDto.Description;
            task.DueOn = taskDto.DueOn;
            task.IsCompleted = false;
            task.CreatedAt = Clock.Instance.Now;
            task.UpdatedAt = Clock.Instance.Now;
        }
    }
}