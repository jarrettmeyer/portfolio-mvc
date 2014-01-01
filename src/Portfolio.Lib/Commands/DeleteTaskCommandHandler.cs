using System;
using System.Diagnostics.Contracts;
using NHibernate;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Commands
{
    public class DeleteTaskCommandHandler : ICommandHandler<DeleteTaskCommand, Task>
    {
        private readonly ISession session;
        private Task task;

        public DeleteTaskCommandHandler(ISession session)
        {
            Contract.Requires<ArgumentNullException>(session != null);
            this.session = session;
        }

        public Task Handle(DeleteTaskCommand command)
        {            
            using (var transaction = session.BeginTransaction())
            {
                task = session.Load<Task>(command.Id);
                session.Delete(task);
                transaction.Commit();
                return task;                
            }
        }
    }
}