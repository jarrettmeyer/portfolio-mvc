using System;
using System.Linq;
using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

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

        public Task UpdateTask(TaskInputModel model)
        {
            using (var transaction = repository.BeginTransaction())
            {
                FetchTaskById(model);
                UpdateTaskProperties(model);
                AddNewTagsToTask(model);
                transaction.Commit();
                return task;
            }
        }

        private void AddNewTagsToTask(TaskInputModel model)
        {            
            var newTags = model.Tags.Where(tag => !currentTagIds.Contains(tag.Id));
            foreach (var tagModel in newTags)
            {
                var newId = tagModel.Id;
                var newTag = repository.Load<Tag>(newId);
                task.Tags.Add(newTag);
            }
        }

        private void FetchTaskById(TaskInputModel model)
        {
            task = repository.Load<Task>(model.Id);
            currentTagIds = task.Tags.Select(t => t.Id).ToArray();
        }

        private void UpdateTaskProperties(TaskInputModel model)
        {
            task.Description = model.Description;
            task.DueOn = model.DueOn.SafeParseDateTime();
            task.Title = model.Title;
            task.UpdatedAt = Clock.Instance.Now;
        }
    }
}