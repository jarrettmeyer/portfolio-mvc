using NHibernate;

namespace Portfolio.Data.Queries
{
    public class UpdateTaskImpl : UpdateTask
    {
        private readonly ISession session;
        private ITransaction transaction;

        public UpdateTaskImpl(ISession session)
        {
            this.session = session;
        }

        public override UpdateTaskResponse ExecuteQuery(UpdateTaskRequest parameters)
        {
            using (transaction = session.BeginTransaction())
            {                
                session.Update(parameters.Task);
                transaction.Commit();
            }

            return new UpdateTaskResponse
            {
                IsSuccessful = true
            };
        }
    }
}
