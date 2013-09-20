using System;
using NHibernate;
using Portfolio.Data.Models;

namespace Portfolio.Data.Commands
{
    public class CreateTaskImpl : CreateTask
    {
        private const string DEFAULT_STATUS_ID = "NEW";
        private DateTime createdAt;
        private readonly ISession session;
        private Status status;
        private TaskStatus taskStatus;
        private ITransaction transaction;

        public CreateTaskImpl(ISession session)
        {
            this.session = session;
        }

        public override void ExecuteCommand()
        {
            using (transaction = session.BeginTransaction())
            {
                SetTaskCreatedAt();
                LoadDefaultStatus();
                InsertTask();
                InsertTaskStatus();
                CommitTransaction();
            }
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

        private void InsertTask()
        {
            Task.CurrentStatus = status;
            session.Save(Task);
        }

        private void InsertTaskStatus()
        {            
            taskStatus = new TaskStatus
                             {
                                 Task = Task,
                                 Status = status,
                                 IsCompleted = status.IsCompleted,
                                 CreatedAt = createdAt
                             };
            session.Save(taskStatus);
        }

        private void LoadDefaultStatus()
        {
            status = session.Load<Status>(DEFAULT_STATUS_ID);
        }

        private void SetTaskCreatedAt()
        {
            createdAt = DateTime.UtcNow;
            Task.CreatedAt = createdAt;
            Task.UpdatedAt = createdAt;
        }
    }
}
