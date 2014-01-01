using System;
using System.Diagnostics.Contracts;
using NHibernate;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Commands
{
    public class CreateTaskCommandHandler : ICommandHandler<CreateTaskCommand, Task>
    {
        private readonly ISession session;
        private Task task;

        public CreateTaskCommandHandler(ISession session)
        {
            Contract.Requires<ArgumentNullException>(session != null);
            this.session = session;
        }

        public Task Handle(CreateTaskCommand command)
        {
            using (var transaction = session.BeginTransaction())
            {
                task = new Task();
                UpdateTaskProperties(command);
                AddTagsToTask(command);
                PersistTask(transaction);
                return task;
            }
        }

        private void AddTagToTask(int tagId)
        {
            Tag tag = session.Load<Tag>(tagId);
            task.AddTag(tag);
        }

        private void AddTagsToTask(CreateTaskCommand command)
        {
            foreach (int tagId in command.TagIds)
                AddTagToTask(tagId);
        }

        private void PersistTask(ITransaction transaction)
        {
            session.Save(task);
            transaction.Commit();
        }

        private void UpdateTaskProperties(CreateTaskCommand command)
        {
            task.Title = command.Title;
            task.Description = command.Description;
            task.DueOn = command.DueOn;
            task.IsCompleted = false;
            task.CreatedAt = Clock.Instance.Now;
            task.UpdatedAt = Clock.Instance.Now;
        }
    }
}