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
        private Request request;
        private Status status;
        private Task task;
        private TaskStatus taskStatus;
        private ITransaction transaction;

        public CreateTaskImpl(ISession session)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            this.session = session;
        }

        public override Response ExecuteCommand(Request input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            request = input;
            task = input.Task;

            using (transaction = session.BeginTransaction())
            {
                SetTaskCreatedAt();
                LoadDefaultStatus();
                InsertTask();
                InsertTaskStatus();
                CommitTransaction();
            }

            return new Response { Id = task.Id };
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
                                 IPAddress = request.UserSettings.IPAddress,
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
