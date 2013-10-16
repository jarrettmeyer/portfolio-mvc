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
        private Task task;
        private TaskStatus taskStatus;
        private ITransaction transaction;

        public CreateTaskImpl(ISession session)
        {
            this.session = session;
        }

        public override CreateTask.Response ExecuteCommand(CreateTask.Request input)
        {
            this.task = input.Task;

            using (transaction = session.BeginTransaction())
            {
                SetTaskCreatedAt();
                LoadDefaultStatus();
                InsertTask();
                InsertTaskStatus();
                CommitTransaction();
            }

            return new CreateTask.Response { Id = task.Id };
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
            task.CurrentStatus = status;
            session.Save(task);
        }

        private void InsertTaskStatus()
        {            
            taskStatus = new TaskStatus
                             {
                                 Task = task,
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
            task.CreatedAt = createdAt;
            task.UpdatedAt = createdAt;
        }
    }
}
