using System.Web.Mvc;
using FluentAssertions;
using NUnit.Framework;

namespace Portfolio.Web.Lib
{
    public class ViewResultBuilderTests
    {
        private Controller controller;
        private int[] model = { 1, 2, 3, 4 };
        private ViewResult viewResult;

        [SetUp]
        public void before_each_test()
        {
            // Create a new controller
            controller = new TestController
            {
                ControllerContext = new ControllerContext()
            };

            viewResult = new ViewResultBuilder()
                .Controller(controller)
                .ViewName("my_view")
                .Model(model)
                .ViewResult;
            
        }

        [Test]
        public void has_expected_model()
        {
            viewResult.Model.Should().BeSameAs(model);
        }

        [Test]
        public void has_expected_view_name()
        {
            viewResult.ViewName.Should().Be("my_view");
        }

        internal class TestController : Controller
        {
            
        }
    }
}
