using System.Web.Mvc;
using Portfolio.Lib;

namespace Portfolio.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new SessionBasedAuthorizeAttibute());
        }
    }
}