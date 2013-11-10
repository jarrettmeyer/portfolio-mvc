using NHibernate;
using Portfolio.Web.Models;

namespace Portfolio.Web.Lib.Queries
{
    public abstract class DeleteTaskById : AbstractQuery<int, int>
    {
    }

    public class DeleteTaskByIdImpl : DeleteTaskById
    {
        private readonly ISession session;
        private Task task;
        private ITransaction transaction;

        public DeleteTaskByIdImpl(ISession session)
        {
            this.session = session;
        }

        public override int ExecuteQuery(int id)
        {
            using (transaction = session.BeginTransaction())
            {
                task = session.Load<Task>(id);
                session.Delete(task);
                transaction.Commit();
                return 1; // row count
            }
        }
    }
}
