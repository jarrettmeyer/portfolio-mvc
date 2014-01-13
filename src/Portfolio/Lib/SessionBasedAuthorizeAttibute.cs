using System.Web;
using System.Web.Mvc;
using Portfolio.Lib.Models;
using Portfolio.Lib.Queries;

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
                SetHttpContextUser(httpContext, httpSessionAdapter);
                return true;
            }
            else
            {
                return false;
            }            
        }

        private static void SetHttpContextUser(HttpContextBase httpContext, IHttpSessionAdapter httpSession)
        {
            var mediator = Mediator.Instance;
            var query = new UserByUsernameQuery(httpSession.Username);
            var user = mediator.Request(query);
            httpContext.User = user ?? new Guest();
        }
    }
}