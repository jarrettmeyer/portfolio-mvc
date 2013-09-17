using System;
using System.Data;
using NHibernate;
using NUnit.Framework;
using Portfolio.Data.Commands;
using Portfolio.Data.Models;

namespace Portfolio.Tests.Data.Commands
{
    [TestFixture]
    public class CreateTaskImplTests
    {
        private CreateTask createTask;
        private IDbConnection connection;
        private ISession session;
        private Task task;
        private Guid taskId;

        [SetUp]
        public void BeforeEachTest()
        {
            //connection = TestBootstrapper.ConnectToDatabase();
            //createTask = new CreateTaskImpl(connection);
        }

        [TearDown]
        public void AfterEachTest()
        {
            createTask.Dispose();
        }

        [Test]
        public void CanInsertTask()
        {
            task = new Task { Description = "Test" };
            createTask.Task = task;
            createTask.ExecuteCommand();
            //taskId = task.Id;


        }
    }

}
