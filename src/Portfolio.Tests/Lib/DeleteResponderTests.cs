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
using Portfolio.Lib.Commands;

namespace Portfolio.Lib
{
    [TestFixture]
    public class DeleteResponderTests
    {
        private ICommand<object> command;
        private ApplicationController controller;
        private DeleteResponder deleteResponder;
        private Mock<HttpContextBase> mockHttpContext;
        private Mock<IMediator> mockMediator;

        [SetUp]
        public void Before_each_test()
        {            
            mockHttpContext = new Mock<HttpContextBase>();
            mockMediator = new Mock<IMediator>();

            controller = new FakeController();
            controller.ControllerContext = new ControllerContext(mockHttpContext.Object, new RouteData(), controller);
            controller.RouteData.Values.Add("controller", "Tasks");
            controller.RouteData.Values.Add("action", "Delete");

            deleteResponder = new DeleteResponder(controller);

            command = new FakeCommand();
        }

        [Test]
        public void Should_add_flash_message()
        {
            deleteResponder.RespondWith(mockMediator.Object, command);
            var flashMessage = controller.TempData.GetFlashMessages().First();
            flashMessage.Key.Should().Be("success");
            flashMessage.Message.Should().Be("Successfully deleted task");
        }

        [Test]
        public void Should_send_command_to_mediator()
        {
            deleteResponder.RespondWith(mockMediator.Object, command);
            mockMediator.Verify(x => x.Send(command));            
        }

        [Test]
        public void Should_return_a_JSON_result()
        {
            var actionResult = deleteResponder.RespondWith(mockMediator.Object, command);
            var jsonResult = MvcTest.HasExpectedActionResult<JsonResult>(actionResult);
            var objectDictionary = jsonResult.Data.ToDictionary();
            objectDictionary["success"].Should().Be(true);
        }

        class FakeController : ApplicationController { }
        
        class FakeCommand : ICommand<object> { }
    }
}
