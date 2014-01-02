using System;
using System.Diagnostics.Contracts;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Queries
{
    public class TasksByTagQueryHandler : IQueryHandler<TasksByTagQuery, TaskCollection>
    {
        private readonly ISession session;

        public TasksByTagQueryHandler(ISession session)
        {
            Contract.Requires<ArgumentNullException>(session != null);
            this.session = session;
        }

        public TaskCollection Handle(TasksByTagQuery query)
        {
            var tasks = session.Query<Task>()
                .Where(t => t.Tags.Any(tag => tag.Slug == query.Tagged));
            return new TaskCollection(tasks);
        }
    }
}
