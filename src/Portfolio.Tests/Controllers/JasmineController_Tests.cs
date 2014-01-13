using System.Web.Mvc;
using NUnit.Framework;

namespace Portfolio.Controllers
{
    [TestFixture]
    public class JasmineController_Tests
    {
        private JasmineController controller;

        [SetUp]
        public void Before_each_test()
        {
            controller = new JasmineController();
        }

        [Test]
        public void Run_returns_view_result()
        {
            var actionResult = controller.Run();
            MvcTest.HasExpectedActionResult<ViewResult>(actionResult);
        }
    }
}
