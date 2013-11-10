using NHibernate;
using Portfolio.Common;
using Portfolio.Data.Queries;
using Portfolio.Web.Models;

namespace Portfolio.Web.Lib.Queries
{
    public class UpdateTaskStatus : AbstractQuery<UpdateTaskStatusRequest, UpdateTaskStatusResponse>
    {
        private UpdateTaskStatusRequest request;
        private readonly ISession session;
        private Task task;
        private Status toStatus;
        private ITransaction transaction;        

        public UpdateTaskStatus(ISession session)
        {
            Ensure.ArgumentIsNotNull(session, "session");
            
            this.session = session;            
        }

        public override UpdateTaskStatusResponse ExecuteQuery(UpdateTaskStatusRequest input)
        {
            this.request = input;

            using (transaction = session.BeginTransaction())
            {
                FetchTaskById(request.TaskId);
                FetchToStatus(request.ToStatus);
                UpdateTask();
                InsertTaskStatus(input.Comment);
                CommitTransaction();
            }

            return new UpdateTaskStatusResponse(task);
        }

        protected override void OnDisposing()
        {
            if (session != null)
            {
                session.Close();
                session.Dispose();
            }
        }

        private void CommitTransaction()
        {
            transaction.Commit();
        }

        private void FetchToStatus(string status)
        {
            toStatus = session.Load<Status>(status);
        }

        private void FetchTaskById(int id)
        {
            task = session.Load<Task>(id);
        }

        private void InsertTaskStatus(string comment)
        {
            var taskStatus = new TaskStatus
            {
                Task = task,
                ToStatus = toStatus,
                IsCompleted = toStatus.IsCompleted,
                Comment = comment,
                IPAddress = request.IPAddress,
                CreatedAt = request.Timestamp
            };
            session.Save(taskStatus);
        }

        private void UpdateTask()
        {
            task.CurrentStatus = toStatus;
            task.IsCompleted = toStatus.IsCompleted;
            task.UpdatedAt = request.Timestamp;
        }
    }
}
