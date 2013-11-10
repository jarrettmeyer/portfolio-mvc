using FluentAssertions;
using Moq;
using NUnit.Framework;
using Portfolio.Controllers;
using Portfolio.Web.Lib;

namespace Portfolio.Web.Controllers
{
    public class HomeControllerTests
    {
        private Mock<ActionResolver> mockActionResolver;
        private HomeController controller;

        [SetUp]
        public void before_each_test()
        {
            mockActionResolver = new Mock<ActionResolver>
            {
                DefaultValue = DefaultValue.Mock
            };
            controller = new HomeController(mockActionResolver.Object);
        }

        [Test]
        public void get_index()
        {
            var actionResult = controller.Index();
            actionResult.Should().BeAssignableTo<ActionResultWrapper>();
        }
    }
}
