using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Portfolio.Lib.Models;


namespace Portfolio.Lib.Queries
{
    public class OpenTasksQueryHandler : IQueryHandler<OpenTasksQuery, IEnumerable<Task>>
    {
        readonly ISession session;

        public OpenTasksQueryHandler(ISession session)
        {
            this.session = session;
        }

        public IEnumerable<Task> Handle(OpenTasksQuery query)
        {
            return session.Query<Task>()
                .Fetch(t => t.Tags)
                .Where(t => t.IsCompleted == false)
                .ToArray();            
        }
    }
}
