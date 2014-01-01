using System.Web;
using System.Web.Mvc;
using Portfolio.Lib.Models;
using Portfolio.Lib.Queries;
using Portfolio.Lib.Services;

namespace Portfolio.Lib
{
    public class SessionBasedAuthorizeAttibute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // If the session object has not yet been created, then there is nothing
            // we can do with this authorization.
            if (httpContext.Session == null)
                return false;

            IHttpSessionAdapter httpSessionAdapter = HttpSessionAdapter.Deserialize(httpContext.Session);
            if (httpSessionAdapter.IsAuthenticated)
            {
                var mediator = ServiceLocator.Instance.GetService<IMediator>();
                var query = new UserByUsernameQuery(httpSessionAdapter.Username);
                var user = mediator.Request(query);
                httpContext.User = user ?? new Guest();
                return true;
            }
            else
            {
                return false;
            }            
        }
    }
}