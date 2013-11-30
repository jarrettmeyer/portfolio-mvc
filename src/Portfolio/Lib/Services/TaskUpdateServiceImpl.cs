using System.Collections.Generic;
using System.Linq;
using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    public class TaskUpdateServiceImpl : ITaskUpdateService
    {
        private string[] currentTagSlugs;
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
                RemoveOldTagsFromTask(model);
                transaction.Commit();
                return task;
            }
        }

        private void AddNewTagsToTask(TaskInputModel model)
        {            
            var newTags = model.Tags.Where(tag => !currentTagSlugs.Contains(tag.Slug));
            foreach (var tagModel in newTags)
            {
                int newId = tagModel.Id;
                Tag newTag = repository.Load<Tag>(newId);
                task.Tags.Add(newTag);
            }
        }

        private void FetchTaskById(TaskInputModel model)
        {
            task = repository.Load<Task>(model.Id);
            currentTagSlugs = task.Tags.Select(t => t.Slug).ToArray();
        }

        private void RemoveOldTagsFromTask(TaskInputModel model)
        {
            IEnumerable<string> selectedSlugs = model.Tags.Select(t => t.Slug);
            IEnumerable<string> oldTagSlugs = currentTagSlugs.Where(slug => !selectedSlugs.Contains(slug));
            foreach (var oldTagSlug in oldTagSlugs)
            {
                string slugToRemove = oldTagSlug;
                Tag oldTag = task.Tags.Single(t => t.Slug == slugToRemove);
                task.Tags.Remove(oldTag);
            }
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