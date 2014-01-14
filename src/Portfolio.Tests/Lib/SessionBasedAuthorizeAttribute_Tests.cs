using System.Web;
using System.Web.Mvc;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Portfolio.Lib.Models;
using Portfolio.Lib.Queries;

namespace Portfolio.Lib
{
    [TestFixture]
    public class SessionBasedAuthorizeAttribute_Tests
    {
        private AuthorizeAttribute attribute;
        private AuthorizationContext authorizationContext;

        [SetUp]
        public void Before_each_test()
        {
            attribute = new SessionBasedAuthorizeAttibute();

            var controller = new FakeController();
            MvcTest.SetupControllerContext(controller);

            authorizationContext = new AuthorizationContext();
            authorizationContext.Controller = controller;
            authorizationContext.HttpContext = controller.HttpContext;

            var controllerDescriptor = new ReflectedControllerDescriptor(typeof(FakeController));
            var method = typeof(FakeController).GetMethod("Nothing");
            authorizationContext.ActionDescriptor = new ReflectedActionDescriptor(method, "Nothing", controllerDescriptor);
        }

        [Test]
        public void Fails_when_session_is_not_authenticated()
        {
            SetupSession(false);
            Authorize();
            AssertUnauthorized();
        }

        [Test]
        public void Fails_when_session_is_null()
        {
            Mock.Get(authorizationContext.HttpContext).SetupGet(x => x.Session).Returns((HttpSessionStateBase)null);
            Authorize();
            AssertUnauthorized();
        }

        [Test]
        public void Succeeds_when_session_is_authenticated()
        {
            SetupSession(true);
            SetupServices();
            Authorize();
            AssertSuccess();
        }

        private void AssertSuccess()
        {
            var user = authorizationContext.HttpContext.User;
            user.Should().BeOfType<User>();
            user.Identity.IsAuthenticated.Should().BeTrue();
            user.Identity.Name.Should().Be("tester");
        }

        private void AssertUnauthorized()
        {
            authorizationContext.Result.Should().BeOfType<HttpUnauthorizedResult>();
        }

        private void Authorize()
        {
            attribute.OnAuthorization(authorizationContext);
        }

        private void SetupServices()
        {
            var mediator = new Mock<IMediator>();
            mediator.Setup(x => x.Request(It.IsAny<UserByUsernameQuery>())).Returns(new User { Username = "tester" });
            Mediator.Instance = mediator.Object;
        }

        private void SetupSession(bool isAuthorized = true)
        {
            var mockContext = Mock.Get(authorizationContext.HttpContext);
            var mockSession = new Mock<HttpSessionStateBase>();
            mockSession.SetupGet(x => x["IsAuthenticated"]).Returns(isAuthorized);

            // Return the mock.
            mockContext.SetupGet(x => x.Session).Returns(mockSession.Object);
        }

        internal class FakeController : Controller
        {
            public ActionResult Nothing()
            {
                return new EmptyResult();
            }
        }
    }
}
