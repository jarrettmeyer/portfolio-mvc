using System.Web.Mvc;
using FluentAssertions;
using NUnit.Framework;

namespace Portfolio.Controllers
{
    public class HomeControllerTests
    {
        private HomeController controller;

        [SetUp]
        public void Before_each_test()
        {
            controller = new HomeController();
        }

        [Test]
        public void Controller_should_exist()
        {
            controller.Should().BeAssignableTo<HomeController>();
        }

        [Test]
        public void GetIndex_should_redirect_to_tasks_index()
        {
            var actionResult = controller.Index();
            actionResult.Should().BeAssignableTo<RedirectToRouteResult>();
            var routeValues = ((RedirectToRouteResult)actionResult).RouteValues;
            routeValues["Controller"].Should().Be("Tasks");
            routeValues["Action"].Should().Be("Index");
        }
    }
}
