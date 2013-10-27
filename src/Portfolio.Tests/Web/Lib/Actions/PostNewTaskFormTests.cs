using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Portfolio.Common;
using Portfolio.Data.Commands;
using Portfolio.Data.Models;
using Portfolio.Data.Queries;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Lib.Actions
{
    public class PostNewTaskFormTests
    {
        private PostNewTaskForm actionResult;
        private ControllerContext controllerContext;
        private TaskInputModel form;
        private Mock<IClock> mockClock;
        private Mock<CreateTask> mockCreateTask;
        private Mock<HttpRequestBase> mockHttpRequest;
        private DateTime now;

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

            // Setup controller context
            controllerContext = new ControllerContext();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            form = new TaskInputModel();
            actionResult = new StubPostNewTaskForm(mockCreateTask.Object, mockHttpRequest.Object, mockClock.Object)
                .WithForm(form);
        }

        [TearDown]
        public void after_each_test()
        {
            RouteTable.Routes.Clear();
        }

        [Test]
        public void request_ip_address_should_be_set()
        {
            actionResult.ExecuteResult(controllerContext);
            actionResult.CreateTaskRequest.IPAddress.Should().Be("1.2.3.4");
        }

        [Test]
        public void should_execute_create_task_query()
        {
            actionResult.ExecuteResult(controllerContext);
            mockCreateTask.Verify(x => x.ExecuteQuery(It.IsAny<CreateTaskRequest>()), Times.Once());
        }

        internal class StubPostNewTaskForm : PostNewTaskForm
        {
            public StubPostNewTaskForm(CreateTask createTask, HttpRequestBase httpRequest, IClock clock) 
                : base(createTask, httpRequest, clock)
            {
            }

            public bool IsRedirected { get; private set; }

            protected override void RedirectToTask(ControllerContext context)
            {
                IsRedirected = true;
            }
        }
    }
}
