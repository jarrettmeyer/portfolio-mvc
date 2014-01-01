using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using NUnit.Framework;

namespace Portfolio
{
    public class MvcTest
    {
        public static TActionResult HasExpectedActionResult<TActionResult>(ActionResult actionResult)
            where TActionResult : ActionResult
        {
            Assert.IsInstanceOf<TActionResult>(actionResult);            
            return (TActionResult)actionResult;
        }

        public static TModel HasExpectedModel<TModel>(ActionResult actionResult)
        {
            var viewResult = actionResult as ViewResult;
            if (viewResult != null)
            {
                var model = viewResult.Model;
                Assert.IsInstanceOf<TModel>(model);
                return (TModel)model;
            }
            Assert.Fail();
            return default(TModel);
        }

        public static void SetupControllerContext(Controller controller)
        {
            HttpContextBase httpContext = Mock.Of<HttpContextBase>();
            RouteData routeData = new RouteData();
            ControllerContext controllerContext = new ControllerContext(httpContext, routeData, controller);
            controller.ControllerContext = controllerContext;
            controller.RouteData.Values["controller"] = controller.GetType().Name;
            controller.RouteData.Values["action"] = "Index";
        }
    }
}
