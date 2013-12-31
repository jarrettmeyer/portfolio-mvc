using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Queries
{
    public class OpenTasksQueryHandler : IQueryHandler<OpenTasksQuery, TaskCollection>
    {
        readonly ISession session;

        public OpenTasksQueryHandler(ISession session)
        {
            this.session = session;
        }

        public TaskCollection Handle(OpenTasksQuery query)
        {
            var tasks = session.Query<Task>()
                .Fetch(t => t.Tags)
                .Where(t => t.IsCompleted == false)
                .OrderBy(t => t.DueOn).ThenBy(t => t.Id);

            return new TaskCollection(tasks);
        }
    }
}
