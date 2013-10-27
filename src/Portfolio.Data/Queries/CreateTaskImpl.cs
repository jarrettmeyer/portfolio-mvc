using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Portfolio.Common;
using Portfolio.Data.Commands;
using Portfolio.Data.Models;

namespace Portfolio.Data.Queries
{
    public class CreateTaskImpl : CreateTask
    {                
        private string ipAddress;
        private readonly ISession session;        
        private Status status;
        private Task task;
        private TaskStatus taskStatus;
        private DateTime timestamp;
        private ITransaction transaction;        

        public CreateTaskImpl(ISession session)
        {
            Ensure.ArgumentIsNotNull(session, "session");
            this.session = session;
        }

        public override CreateTaskResponse ExecuteQuery(CreateTaskRequest input)
        {
            Ensure.ArgumentIsNotNull(input, "input");            
            
            task = input.Task;
            ipAddress = input.IPAddress;
            timestamp = input.Timestamp;

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
                ToStatus = status,
                IsCompleted = status.IsCompleted,
                IPAddress = ipAddress,
                CreatedAt = timestamp
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
            task.CreatedAt = timestamp;
            task.UpdatedAt = timestamp;
        }
    }
}
