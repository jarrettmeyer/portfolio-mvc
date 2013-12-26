using System.Linq;
using Portfolio.Lib.Data;
using Portfolio.Lib.DTOs;
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

        public Task UpdateTask(TaskDTO taskDto)
        {
            using (var transaction = repository.BeginTransaction())
            {
                FetchTaskById(taskDto);
                UpdateTaskProperties(taskDto);
                AddNewTagsToTask(taskDto);
                RemoveOldTagsFromTask(taskDto);
                transaction.Commit();
                return task;
            }
        }

        private void AddNewTagsToTask(TaskDTO taskDto)
        {
            if (taskDto.Tags == null)
                return;

            var newTags = taskDto.Tags.Where(tag => !currentTagIds.Contains(tag.Id));
            foreach (var tagModel in newTags)
            {
                int newId = tagModel.Id;
                Tag newTag = repository.Load<Tag>(newId);
                task.AddTag(newTag);                
            }
        }

        private void FetchTaskById(TaskDTO taskDto)
        {
            task = repository.Load<Task>(taskDto.Id);
            currentTagIds = task.Tags.Select(t => t.Id).ToArray();
        }

        private void RemoveOldTagsFromTask(TaskDTO taskDto)
        {
            if (taskDto.Tags == null)
                return;

            var selectedIds = taskDto.Tags.Select(t => t.Id);
            var idsToRemove = currentTagIds.Where(id => !selectedIds.Contains(id));
            foreach (var idToRemove in idsToRemove)
            {
                int id = idToRemove;
                task.RemoveTag(id);                
            }
        }

        private void UpdateTaskProperties(TaskDTO taskDto)
        {
            task.Description = taskDto.Description;
            task.DueOn = taskDto.DueOn;
            task.Title = taskDto.Title;
            task.UpdatedAt = Clock.Instance.Now;
        }
    }
}