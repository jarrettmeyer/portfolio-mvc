using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Portfolio.Common;
using Portfolio.Data.Models;

namespace Portfolio.Data.Commands.Impl
{
    public class CreateTaskImpl : CreateTask
    {
        private readonly IClock clock;
        private DateTime createdAt;
        private readonly ISession session;        
        private Status status;
        private Task task;
        private TaskStatus taskStatus;
        private ITransaction transaction;
        private readonly IUserSettings userSettings;

        public CreateTaskImpl(ISession session, IUserSettings userSettings, IClock clock)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (userSettings == null)
                throw new ArgumentNullException("userSettings");

            if (clock == null)
                throw new ArgumentNullException("clock");

            this.session = session;
            this.userSettings = userSettings;
            this.clock = clock;
        }

        public override CreateTaskResponse ExecuteCommand(CreateTaskRequest input)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            
            task = input.Task;

            using (transaction = session.BeginTransaction())
            {
                SetTaskCreatedAt();
                LoadDefaultStatus();
                InsertTask();
                InsertTaskStatus();
                CommitTransaction();
            }

            return new CreateTaskResponse(task);
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
                IPAddress = userSettings.IPAddress,
                CreatedAt = createdAt
            };
            session.Save(taskStatus);
        }

        private void LoadDefaultStatus()
        {
            status = session.Query<Status>().FirstOrDefault(s => s.IsDefaultStatus);
            if (status == null)
            {
                throw new NullReferenceException("Could not find a default status in the database.");
            }
        }

        private void SetTaskCreatedAt()
        {
            createdAt = clock.Now;
            task.CreatedAt = createdAt;
            task.UpdatedAt = createdAt;
        }
    }
}
