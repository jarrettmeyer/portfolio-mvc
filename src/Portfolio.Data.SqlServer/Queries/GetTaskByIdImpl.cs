using NHibernate;
using Portfolio.Data.Models;

namespace Portfolio.Data.Queries
{
    public class GetTaskByIdImpl : GetTaskById
    {
        private readonly ISession session;

        public GetTaskByIdImpl(ISession session)
        {
            this.session = session;
        }

        public override Task ExecuteQuery()
        {
            return session.Load<Task>(Id);            
        }

        protected override void OnDisposing()
        {
            if (session != null)
            {
                session.Close();
                session.Dispose();
            }
        }
    }
}
