using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Portfolio.Lib;
using Portfolio.Lib.Actions;
using Portfolio.Models;
using Portfolio.ViewModels;
using Portfolio.Web.Lib.Queries;

namespace Portfolio.Web.Lib.Actions
{
    public class PostNewTaskFormTests
    {
        private IAction action;
        private TaskInputModel form;
        private Mock<IClock> mockClock;
        private Mock<CreateTask> mockCreateTask;
        private Mock<HttpRequestBase> mockHttpRequest;
        private DateTime now;
        private TempDataDictionary tempData;

        [SetUp]
        public void before_each_test()
        {
            // Setup create task
            mockCreateTask = new Mock<CreateTask>
            {
                DefaultValue = DefaultValue.Mock
            };
            mockCreateTask.Setup(x => x.ExecuteQuery(It.IsAny<CreateTaskRequest>())).Returns(new CreateTaskResponse(new Task()));

            // Setup HTTP request
            mockHttpRequest = new Mock<HttpRequestBase>();
            mockHttpRequest.SetupGet(x => x.UserHostAddress).Returns("1.2.3.4");

            // Setup clock
            now = new DateTime();
            mockClock = new Mock<IClock>();
            mockClock.SetupGet(x => x.Now).Returns(now);

            tempData = new TempDataDictionary();

            form = new TaskInputModel();
            //action = new PostNewTaskForm(mockCreateTask.Object, mockHttpRequest.Object, mockClock.Object)
            //    .WithForm(form)
            //    .WithTempData(tempData);
        }

        [TearDown]
        public void after_each_test()
        {
            RouteTable.Routes.Clear();
        }

        [Test]
        public void request_ip_address_should_be_set()
        {
            action.Execute();
            //((PostNewTaskForm)action).CreateTaskRequest.IPAddress.Should().Be("1.2.3.4");
        }

        [Test]
        public void should_execute_create_task_query()
        {
            action.Execute();
            mockCreateTask.Verify(x => x.ExecuteQuery(It.IsAny<CreateTaskRequest>()), Times.Once());
        }
    }
}
