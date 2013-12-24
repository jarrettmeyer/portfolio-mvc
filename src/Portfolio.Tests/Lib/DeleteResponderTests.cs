using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FluentAssertions;
using Moq;
using MvcFlashMessages;
using NUnit.Framework;
using Portfolio.Controllers;
using Portfolio.Lib.Data;
using Portfolio.Lib.Services;

namespace Portfolio.Lib
{
    [TestFixture]
    public class DeleteResponderTests
    {
        private TasksController controller;
        private DeleteResponder deleteResponder;
        private Mock<HttpContextBase> mockHttpContext;
        private MockServiceLocator mockServiceLocator;

        [SetUp]
        public void Before_each_test()
        {            
            MockServiceLocator.Reset();
            mockServiceLocator = new MockServiceLocator();            
            ServiceLocator.Instance = mockServiceLocator;

            mockHttpContext = new Mock<HttpContextBase>();

            controller = new TasksController();
            controller.ControllerContext = new ControllerContext(mockHttpContext.Object, new RouteData(), controller);
            controller.RouteData.Values.Add("controller", "Tasks");
            controller.RouteData.Values.Add("action", "Delete");

            deleteResponder = new DeleteResponder(controller);
        }

        [Test]
        public void Should_add_flash_message()
        {
            deleteResponder.RespondWith<ITaskDeletionService>(x => x.DeleteTask(1));
            var flashMessage = controller.TempData.GetFlashMessages().First();
            flashMessage.Key.Should().Be("success");
            flashMessage.Message.Should().Be("Successfully deleted task");
        }

        [Test]
        public void Should_invoke_the_expected_service()
        {
            deleteResponder.RespondWith<ITaskDeletionService>(x => x.DeleteTask(1));
            MockServiceLocator.GetMock<ITaskDeletionService>().Verify(x => x.DeleteTask(1), Times.Once());
        }

        [Test]
        public void Should_return_a_JSON_result()
        {
            var actionResult = deleteResponder.RespondWith<ITaskDeletionService>(x => x.DeleteTask(1));
            actionResult.Should().BeAssignableTo<JsonResult>();

            var jsonResult = (JsonResult)actionResult;
            var objectDictionary = jsonResult.Data.ToDictionary();
            objectDictionary["success"].Should().Be(true);
        }
    }
}
