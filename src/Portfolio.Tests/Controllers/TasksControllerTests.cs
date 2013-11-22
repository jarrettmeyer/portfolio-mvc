using System;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Portfolio.Lib.Data;
using Portfolio.Lib.Services;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    [TestFixture]
    public class TasksControllerTests
    {
        private TasksController tasksController;

        [SetUp]
        public void Before_each_test()
        {
            tasksController = new TasksController();
        }

        [Test]
        public void It_should_exist()
        {
            tasksController.Should().BeAssignableTo<TasksController>();
        }

        public class TaskControllerTestContext
        {            
            public void SetUpContext()
            {
                // Initialize the controller.
                Controller = new TasksController();
                Task = new Task();
                TaskInputModel = new TaskInputModel();

                // Initialize the service locator.
                MockServiceLocator = new Mock<IServiceLocator>
                {
                    DefaultValue = DefaultValue.Mock
                };
                ServiceLocator.Instance = MockServiceLocator.Object;

                // Initialize the repository
                MockRepository = new Mock<IRepository>();
                MockServiceLocator.Setup(x => x.GetService<IRepository>()).Returns(MockRepository.Object);
                MockRepository.Setup(x => x.Add(It.IsAny<Task>()))
                    .Callback<Task>(t =>
                    {
                        Task = t;
                        Task.Id = 1;
                    });
                MockRepository.Setup(x => x.Load<Task>(It.IsAny<int>()))
                    .Returns(Task)
                    .Callback<int>(i => Task.Id = i);

                // Initialize the task creation service.
                MockTaskCreationSerivce = new Mock<ITaskCreationService>
                {
                    DefaultValue = DefaultValue.Mock
                };
                MockServiceLocator.Setup(x => x.GetService<ITaskCreationService>()).Returns(MockTaskCreationSerivce.Object);
            }

            public TasksController Controller { get; set; }
            public Task Task { get; set; }
            public TaskInputModel TaskInputModel { get; set; }
            public Mock<IRepository> MockRepository { get; set; }
            public Mock<IServiceLocator> MockServiceLocator { get; set; }
            public Mock<ITaskCreationService> MockTaskCreationSerivce { get; set; }
        }

        public class GetIndex : TaskControllerTestContext
        {
            [SetUp]
            public void Before_each_test()
            {
                SetUpContext();                
            }

            [Test]
            public void It_fetches_tasks()
            {
                Controller.Index();
                MockRepository.Verify(x => x.FindAll<Task>(null, null), Times.Once());
            }

            [Test]
            public void It_assigns_the_expected_view_model()
            {
                var actionResult = Controller.Index();
                object model = ((ViewResult)actionResult).Model;
                model.Should().BeAssignableTo<TaskListViewModel>();
            }

            [Test]
            public void It_Returns_a_view()
            {
                var actionResult = Controller.Index();
                actionResult.Should().BeAssignableTo<ViewResult>();
            }
        }

        public class GetNew : TaskControllerTestContext
        {
            [SetUp]
            public void Before_each_test()
            {
                SetUpContext();
            }

            [Test]
            public void It_returns_a_view()
            {
                var actionResult = Controller.New();
                actionResult.Should().BeAssignableTo<ViewResult>();
            }

            [Test]
            public void It_has_the_expected_view_model()
            {
                var actionResult = Controller.New();
                var model = ((ViewResult)actionResult).Model;
                model.Should().BeAssignableTo<TaskInputModel>();
            }
        }

        public class PostNewWorks : TaskControllerTestContext
        {
            [SetUp]
            public void Before_each_test()
            {
                SetUpContext();
            }

            [Test]
            public void It_saves_a_new_task()
            {
                Controller.New(TaskInputModel);
                MockTaskCreationSerivce.Verify(x => x.CreateTask(TaskInputModel), Times.Once());
            }

            [Test]
            public void It_adds_a_success_message()
            {
                Controller.New(TaskInputModel);
                var flashMessage = Controller.FlashMessages.First(m => m.Key == "success");
                flashMessage.Message.Should().Contain("Created new task:");                
            }

            [Test]
            public void It_redirects_to_show()
            {
                var actionResult = Controller.New(TaskInputModel);
                var routeValues = ((RedirectToRouteResult)actionResult).RouteValues;
                routeValues["Action"].Should().Be("Show");
            }
        }

        public class GetEdit : TaskControllerTestContext
        {
            [SetUp]
            public void Before_each_test()
            {
                SetUpContext();
            }

            [Test]
            public void It_fetches_a_task()
            {
                Controller.Edit(123);
                MockRepository.Verify(x => x.Load<Task>(123), Times.Once());
            }

            [Test]
            public void It_has_the_expected_view_model()
            {
                var actionResult = Controller.Edit(123);
                object model = ((ViewResult)actionResult).Model;
                model.Should().BeAssignableTo<TaskInputModel>();
                var taskInputModel = (TaskInputModel)model;
                taskInputModel.Id.Should().Be(123);
            }
        }
    }
}
