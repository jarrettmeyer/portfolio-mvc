using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Portfolio.Lib;

namespace Portfolio.Controllers
{
    [TestFixture]
    public class ApplicationControllerTests
    {
        private ApplicationController controller;

        [Test]
        public void Can_get_and_set_session_adapter()
        {
            controller = new FakeController();
            IHttpSessionAdapter sessionAdapter = new Mock<IHttpSessionAdapter>().Object;
            controller.SessionAdapter = sessionAdapter;
            controller.SessionAdapter.Should().BeSameAs(sessionAdapter);
        }

        [Test]
        public void Can_get_a_default_session_adapter()
        {
            controller = new FakeController();                    
            controller.ControllerContext = new ControllerContext(
                httpContext: new Mock<HttpContextBase> { DefaultValue = DefaultValue.Mock }.Object, 
                routeData: new RouteData(), 
                controller: controller);
            controller.SessionAdapter.Should().BeAssignableTo<IHttpSessionAdapter>();
        }

        /// <summary>
        /// The ApplicationController is abstract. We need a concrete instance.
        /// </summary>
        public class FakeController : ApplicationController
        {            
        }
    }
}
