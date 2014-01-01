using System;
using System.Diagnostics.Contracts;
using NHibernate;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Commands
{
    public class CompleteTaskCommandHandler : ICommandHandler<CompleteTaskCommand, Task>
    {
        private readonly ISession session;
        private Task task;

        public CompleteTaskCommandHandler(ISession session)
        {
            Contract.Requires<ArgumentNullException>(session != null);
            this.session = session;
        }

        public Task Handle(CompleteTaskCommand command)
        {
            using (var transaction = session.BeginTransaction())
            {
                task = session.Load<Task>(command.Id);
                task.Complete();
                task.UpdatedAt = Clock.Instance.Now;
                transaction.Commit();
                return task;
            }            
        }
    }
}