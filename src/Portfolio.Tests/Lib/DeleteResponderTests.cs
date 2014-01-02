using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FluentAssertions;
using Microsoft.Practices.ServiceLocation;
using Moq;
using MvcFlashMessages;
using NUnit.Framework;
using Portfolio.Controllers;

namespace Portfolio.Lib
{
    [TestFixture]
    public class DeleteResponderTests
    {
        private ApplicationController controller;
        private DeleteResponder deleteResponder;
        private Mock<HttpContextBase> mockHttpContext;        

        [SetUp]
        public void Before_each_test()
        {            
            mockHttpContext = new Mock<HttpContextBase>();

            controller = new FakeController();
            controller.ControllerContext = new ControllerContext(mockHttpContext.Object, new RouteData(), controller);
            controller.RouteData.Values.Add("controller", "Tasks");
            controller.RouteData.Values.Add("action", "Delete");

            deleteResponder = new DeleteResponder(controller);
        }

        [Test, Ignore]
        public void Should_add_flash_message()
        {
            //deleteResponder.RespondWith<ITaskDeletionService>(x => x.DeleteTask(1));
            var flashMessage = controller.TempData.GetFlashMessages().First();
            flashMessage.Key.Should().Be("success");
            flashMessage.Message.Should().Be("Successfully deleted task");
        }

        [Test, Ignore]
        public void Should_invoke_the_expected_service()
        {
            //deleteResponder.RespondWith<ITaskDeletionService>(x => x.DeleteTask(1));
            //MockServiceLocator.GetMock<ITaskDeletionService>().Verify(x => x.DeleteTask(1), Times.Once());
        }

        [Test, Ignore]
        public void Should_return_a_JSON_result()
        {
            //var actionResult = deleteResponder.RespondWith<ITaskDeletionService>(x => x.DeleteTask(1));
            //actionResult.Should().BeAssignableTo<JsonResult>();

            //var jsonResult = (JsonResult)actionResult;
            //var objectDictionary = jsonResult.Data.ToDictionary();
            //objectDictionary["success"].Should().Be(true);
        }

        class FakeController : ApplicationController
        {
        }
    }
}
