using System.Linq;
using Portfolio.Lib.Data;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Services
{
    public class TaskUpdateServiceImpl : ITaskUpdateService
    {
        private int[] currentTagIds;
        private readonly IRepository repository;
        private Task task;

        public TaskUpdateServiceImpl(IRepository repository)
        {
            Ensure.ArgumentIsNotNull(repository, "repository");
            this.repository = repository;
        }

        public Task UpdateTask(Task model)
        {
            using (var transaction = repository.BeginTransaction())
            {
                FetchTaskById(model);
                UpdateTaskProperties(model);
                AddNewTagsToTask(model);
                RemoveOldTagsFromTask(model);
                transaction.Commit();
                return task;
            }
        }

        private void AddNewTagsToTask(Task model)
        {            
            var newTags = model.Tags.Where(tag => !currentTagIds.Contains(tag.Id));
            foreach (var tagModel in newTags)
            {
                int newId = tagModel.Id;
                Tag newTag = repository.Load<Tag>(newId);
                task.AddTag(newTag);                
            }
        }

        private void FetchTaskById(Task model)
        {
            task = repository.Load<Task>(model.Id);
            currentTagIds = task.Tags.Select(t => t.Id).ToArray();
        }

        private void RemoveOldTagsFromTask(Task model)
        {
            var selectedIds = model.Tags.Select(t => t.Id);
            var idsToRemove = currentTagIds.Where(id => !selectedIds.Contains(id));
            foreach (var idToRemove in idsToRemove)
            {
                int id = idToRemove;
                task.RemoveTag(id);                
            }
        }

        private void UpdateTaskProperties(Task model)
        {
            task.Description = model.Description;
            task.DueOn = model.DueOn;
            task.Title = model.Title;
            task.UpdatedAt = Clock.Instance.Now;
        }
    }
}