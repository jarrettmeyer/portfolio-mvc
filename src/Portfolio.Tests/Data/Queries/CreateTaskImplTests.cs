using System;
using System.Linq;
using FluentAssertions;
using Moq;
using NHibernate;
using NHibernate.Linq;
using NUnit.Framework;
using Portfolio.Common;
using Portfolio.Web.Lib.Queries;
using Portfolio.Web.Models;

namespace Portfolio.Data.Queries
{
    [TestFixture]
    public class CreateTaskImplTests
    {
        private CreateTask createTask;
        private Mock<IClock> mockClock;
        private Mock<IUserSettings> mockUserSettings;
        private DateTime now;
        private CreateTaskRequest request;
        private CreateTaskResponse response;        
        private ISession session;
        private Task task;

        [SetUp]
        public void before_each_test()
        {
            SetUpTestData();
            CreateNewSession();

            mockUserSettings = new Mock<IUserSettings>();
            mockUserSettings.SetupGet(x => x.IPAddress).Returns("1.2.3.4");

            now = DateTime.Now;
            mockClock = new Mock<IClock>();
            mockClock.SetupGet(x => x.Now).Returns(now);

            createTask = new CreateTaskImpl(session);
            
        }

        [TearDown]
        public void after_each_test()
        {
            PurgeTestData();
            DestroySession();
        }

        [Test]
        public void inserts_new_task_and_updates_id()
        {
            ExecuteCreateTaskCommand();
            task.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void new_task_should_have_expected_timestamps()
        {
            ExecuteCreateTaskCommand();
            task.CreatedAt.Should().Be(now);
            task.UpdatedAt.Should().Be(now);
        }

        [Test]
        public void new_task_should_have_expected_due_on_date()
        {
            ExecuteCreateTaskCommand();
            task.DueOn.Should().Be(new DateTime(2013, 12, 31));
        }

        [Test]
        public void new_task_should_have_expected_status()
        {
            ExecuteCreateTaskCommand();
            task.CurrentStatus.Id.Should().Be("NEW");
        }

        [Test]
        public void status_ip_address_should_have_expected_value()
        {
            ExecuteCreateTaskCommand();
            var taskStatus = session.Query<TaskStatus>()
                .Where(ts => ts.Task.Id == task.Id)
                .OrderByDescending(ts => ts.Id)
                .First();
            taskStatus.IPAddress.Should().Be("1.2.3.4");
        }

        private void CreateNewSession()
        {
            session = TestBootstrapper.OpenSession();
        }

        private void DestroySession()
        {
            if (session != null)
            {
                session.Close();
                session.Dispose();
            }
        }

        private void ExecuteCreateTaskCommand()
        {
            task = new Task
            {
                Title = "Testing...",
                Description = "This is a test",
                DueOn = new DateTime(2013, 12, 31)
            };
            request = new CreateTaskRequest(task, null, "1.2.3.4", now);
            response = createTask.ExecuteQuery(request);
        }

        private void PurgeTestData()
        {
            TestBootstrapper.DeleteAllTasks();
            TestBootstrapper.DeleteAll<Status>();
        }

        private void SetUpTestData()
        {
            TestBootstrapper.InsertNewStatus("NEW", isDefaultStatus: true);
        }
    }
}
