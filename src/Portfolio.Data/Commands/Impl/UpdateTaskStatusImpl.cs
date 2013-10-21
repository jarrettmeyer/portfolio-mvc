using System;
using NHibernate;
using Portfolio.Common;
using Portfolio.Data.Models;

namespace Portfolio.Data.Commands.Impl
{
    public class UpdateTaskStatusImpl : UpdateTaskStatus
    {
        private readonly IClock clock;
        private readonly ISession session;
        private Task task;
        private Status toStatus;
        private DateTime timestamp;
        private readonly IUserSettings userSettings;

        public UpdateTaskStatusImpl(ISession session, IUserSettings userSettings, IClock clock)
        {
            Ensure.ArgumentIsNotNull(session, "session");
            Ensure.ArgumentIsNotNull(userSettings, "userSettings");
            Ensure.ArgumentIsNotNull(clock, "clock");

            this.session = session;
            this.userSettings = userSettings;
            this.clock = clock;
        }

        public override UpdateTaskStatusResponse ExecuteCommand(UpdateTaskStatusRequest input)
        {
            SetTimestamp();

            using (var txn = session.BeginTransaction())
            {
                FetchTaskById(input.TaskId);
                FetchToStatus(input.ToStatus);
                UpdateTask();
                InsertTaskStatus(input.Comment);
                txn.Commit();
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
                IPAddress = userSettings.IPAddress,
                CreatedAt = timestamp
            };
            session.Save(taskStatus);
        }

        private void SetTimestamp()
        {
            timestamp = clock.Now;
        }

        private void UpdateTask()
        {
            task.CurrentStatus = toStatus;
            task.IsCompleted = toStatus.IsCompleted;
            task.UpdatedAt = timestamp;
        }
    }
}
