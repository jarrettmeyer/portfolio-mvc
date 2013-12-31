using NHibernate;
using Portfolio.Lib.Models;


namespace Portfolio.Lib.Queries
{
    public class TaskByIdQueryHandler : IQueryHandler<TaskByIdQuery, Task>
    {
        readonly ISession session;

        public TaskByIdQueryHandler(ISession session)
        {
            this.session = session;
        }

        public Task Handle(TaskByIdQuery query)
        {
            int id = query.Id;
            return session.Load<Task>(id);
        }
    }
}
