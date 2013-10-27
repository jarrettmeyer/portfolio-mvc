using NHibernate;
using Portfolio.Common;
using Portfolio.Data.Models;

namespace Portfolio.Data.Queries
{
    public class FetchTaskByIdImpl : FetchTaskById
    {
        private readonly ISession session;

        public FetchTaskByIdImpl(ISession session)
        {
            Ensure.ArgumentIsNotNull(session, "session");
            this.session = session;
        }

        public override Task ExecuteQuery(int id)
        {
            var task = session.Load<Task>(id);
            return task;
        }   
    }
}