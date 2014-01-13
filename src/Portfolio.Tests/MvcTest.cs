using System.Collections.Generic;
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

        public static void RedirectsToRoute(ActionResult actionResult, string controller = null, string action = null)
        {
            RedirectToRouteResult redirectToRouteResult = actionResult as RedirectToRouteResult;
            if (redirectToRouteResult != null)
            {
                if (action != null)
                {
                    Assert.AreEqual(action, redirectToRouteResult.RouteValues["action"]);
                }
                if (controller != null)
                {
                    Assert.AreEqual(controller, redirectToRouteResult.RouteValues["controller"]);
                }
                Assert.Pass();
            }
            Assert.Fail();
        }

        public static void SetupControllerContext(Controller controller)
        {
            HttpContextBase httpContext = Mock.Of<HttpContextBase>();
            Mock.Get(httpContext).SetupGet(x => x.Items).Returns(new Dictionary<object, object>());
            Mock.Get(httpContext).SetupGet(x => x.Response).Returns(Mock.Of<HttpResponseBase>());
            Mock.Get(httpContext.Response).SetupGet(x => x.Cache).Returns(Mock.Of<HttpCachePolicyBase>());
            RouteData routeData = new RouteData();
            ControllerContext controllerContext = new ControllerContext(httpContext, routeData, controller);
            controller.ControllerContext = controllerContext;
            controller.RouteData.Values["controller"] = controller.GetType().Name;
            controller.RouteData.Values["action"] = "Index";
        }
    }
}
