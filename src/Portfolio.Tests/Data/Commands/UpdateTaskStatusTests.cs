using System;
using System.Linq;
using FluentAssertions;
using Moq;
using NHibernate;
using NHibernate.Linq;
using NUnit.Framework;
using Portfolio.Common;
using Portfolio.Data.Models;

namespace Portfolio.Data.Commands
{
    [TestFixture]
    public class UpdateTaskStatusTests
    {
        private Mock<IClock> mockClock;
        private Mock<IUserSettings> mockUserSettings;
        private UpdateTaskStatusRequest request;
        private UpdateTaskStatusResponse response;
        private ISession session;
        private int taskId;
        private readonly DateTime timestamp = DateTime.Now;
        private UpdateTaskStatus updateTaskStatus;

        [SetUp]
        public void before_each_test()
        {
            InsertDummyData();

            // Set up the database session.
            session = TestBootstrapper.OpenSession();

            // Create mocks.
            mockClock = new Mock<IClock>();
            mockClock.SetupGet(x => x.Now).Returns(timestamp);
            mockUserSettings = new Mock<IUserSettings>();
            mockUserSettings.SetupGet(x => x.IPAddress).Returns("1.2.3.4");

            // Create the new command instance.
            updateTaskStatus = new UpdateTaskStatus(session, mockUserSettings.Object, mockClock.Object);
        }

        [TearDown]
        public void after_each_test()
        {
            DeleteAllDatabaseRecords();
            DisposeOfUpdateTaskStatus();
            DisposeOfSession();
        }

        [Test]
        public void creates_new_TaskStatus_entry()
        {
            ExecuteCommand();

            var taskStatus = session.Query<TaskStatus>()
                .Where(ts => ts.Task.Id == taskId)
                .OrderByDescending(ts => ts.CreatedAt)
                .First();

            taskStatus.Should().NotBeNull();
            taskStatus.ToStatus.Id.Should().Be("ST_2");
        }

        [Test]
        public void Task_Status_should_be_updated()
        {
            ExecuteCommand();

            response.Task.CurrentStatus.Id.Should().Be("ST_2");
            response.Task.CurrentStatus.Description.Should().Be("Second Status");
            response.Task.CurrentStatus.IsCompleted.Should().BeTrue();
        }

        [Test]
        public void Task_UpdatedAt_should_be_modified()
        {
            request = new UpdateTaskStatusRequest(taskId, "ST_2", "my comment");
            response.Task.UpdatedAt.Should().Be(timestamp);
        }

        private static void DeleteAllDatabaseRecords()
        {
            TestBootstrapper.DeleteAllTasks();
            TestBootstrapper.DeleteAllStatuses();
        }

        private void DisposeOfSession()
        {
            if (session != null && session.IsOpen)
            {
                session.Close();
                session.Dispose();
            }
        }

        private void DisposeOfUpdateTaskStatus()
        {
            if (updateTaskStatus != null)
            {
                updateTaskStatus.Dispose();
            }
        }

        private void ExecuteCommand()
        {
            request = new UpdateTaskStatusRequest(taskId, "ST_2", "my comment");
            response = updateTaskStatus.ExecuteCommand(request);
        }

        private void InsertDummyData()
        {
            var fromStatus = TestBootstrapper.InsertNewStatus("ST_1", "First Status", false, true);
            TestBootstrapper.InsertNewStatus("ST_2", "Second Status", true, false);
            var task = TestBootstrapper.InsertNewTask("This is a test", fromStatus);
            taskId = task.Id;
        }
    }
}
