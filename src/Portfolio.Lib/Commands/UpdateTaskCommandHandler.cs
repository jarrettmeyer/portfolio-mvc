using System;
using System.Diagnostics.Contracts;
using System.Linq;
using NHibernate;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Commands
{
    public class UpdateTaskCommandHandler : ICommandHandler<UpdateTaskCommand, Task>
    {
        private int[] currentTagIds;
        private readonly ISession session;
        private Task task;

        public UpdateTaskCommandHandler(ISession session)
        {
            Contract.Requires<ArgumentNullException>(session != null);
            this.session = session;
        }

        public Task Handle(UpdateTaskCommand command)
        {
            using (var transaction = session.BeginTransaction())
            {
                FetchTaskById(command);
                UpdateTaskProperties(command);
                AddNewTagsToTask(command);
                RemoveOldTagsFromTask(command);
                transaction.Commit();
                return task;
            }
        }

        private void AddNewTagsToTask(UpdateTaskCommand command)
        {
            var newTagIds = command.TagIds.Where(id => !currentTagIds.Contains(id));
            foreach (int id in newTagIds)
            {
                Tag newTag = session.Load<Tag>(id);
                task.AddTag(newTag);                
            }
        }

        private void FetchTaskById(UpdateTaskCommand command)
        {
            task = session.Load<Task>(command.Id);
            currentTagIds = task.Tags.Select(t => t.Id).ToArray();
        }

        private void RemoveOldTagsFromTask(UpdateTaskCommand command)
        {
            var idsToRemove = currentTagIds.Where(id => !command.TagIds.Contains(id));
            foreach (var idToRemove in idsToRemove)
            {
                int id = idToRemove;
                task.RemoveTag(id);                
            }
        }

        private void UpdateTaskProperties(UpdateTaskCommand command)
        {
            task.Description = command.Description;
            task.DueOn = command.DueOn;
            task.Title = command.Title;
            task.UpdatedAt = Clock.Instance.Now;
        }
    }
}