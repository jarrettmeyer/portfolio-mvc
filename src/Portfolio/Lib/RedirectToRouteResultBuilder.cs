using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace Portfolio.Web.Lib
{
    public class RedirectToRouteResultBuilder
    {
        private Dictionary<string, object> values = new Dictionary<string, object>();

        public RedirectToRouteResult RedirectToRouteResult
        {
            get
            {
                var routeValues = new RouteValueDictionary();
                foreach (var key in values.Keys)
                {
                    routeValues.Add(key, values[key]);
                }                
                var redirect = new RedirectToRouteResult(routeValues);
                return redirect;
            }
        }

        public RedirectToRouteResultBuilder Action(string action)
        {
            return Add("action", action);
        }

        public RedirectToRouteResultBuilder Add(string key, object value)
        {
            values.Add(key, value);
            return this;
        }

        public RedirectToRouteResultBuilder Controller(string controller)
        {
            return Add("controller", controller);
        }

        public RedirectToRouteResultBuilder Id(object value)
        {
            return Add("id", value);
        }
    }
}