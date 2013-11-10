using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Portfolio.Common;
using Portfolio.Web.Models;

namespace Portfolio.Web.Lib.Queries
{
    public class FetchAllTasks : AbstractQuery<IEnumerable<Task>>
    {
        private readonly ISession session;

        public FetchAllTasks(ISession session)
        {
            Ensure.ArgumentIsNotNull(session, "session");
            
            this.session = session;
        }

        public override IEnumerable<Task> ExecuteQuery()
        {
            var tasks = session.Query<Task>()
                .OrderBy(t => t.Id)
                .ToArray();
            return tasks;
        }

        protected override void Dispose(bool isDisposing)
        {
            if (session != null)
                session.Dispose();
        }
    }
}
