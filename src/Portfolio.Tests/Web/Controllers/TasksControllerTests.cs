using FluentAssertions;
using Moq;
using NUnit.Framework;
using Portfolio.Controllers;
using Portfolio.Web.Lib;
using Portfolio.Web.Lib.Actions;

namespace Portfolio.Web.Controllers
{
    [TestFixture]
    public class TasksControllerTests
    {
        private Mock<ActionResolver> mockActionResolver;
        private TasksController tasksController;

        [SetUp]
        public void before_each_test()
        {
            // Set up our fake action resolver.
            mockActionResolver = new Mock<ActionResolver>
            {
                DefaultValue = DefaultValue.Mock
            };
            mockActionResolver.Setup(x => x.GetAction<GetNewTaskView>()).Returns(new GetNewTaskView(null));
            mockActionResolver.Setup(x => x.GetAction<GetTasksIndexView>()).Returns(new GetTasksIndexView(null));

            tasksController = new TasksController(mockActionResolver.Object);
        }

        [Test]
        public void get_index()
        {
            // Action
            var actionResult = tasksController.Index();

            // Assertions
            actionResult.Should().NotBeNull();
            actionResult.Should().BeAssignableTo<ActionResultWrapper>();
        }

        [Test]
        public void get_new()
        {
            // Action
            var actionResult = tasksController.New();

            // Assertions
            actionResult.Should().BeAssignableTo<ActionResultWrapper>();
        }
    }
}
