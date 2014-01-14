using System.Diagnostics.Contracts;
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
            Contract.Requires(httpContext != null, "HTTP Context cannot be null.");

            // If the session object has not yet been created, then there is nothing
            // we can do with this authorization.
            if (httpContext.Session == null)
                return false;

            IHttpSessionAdapter httpSession = GetHttpSessionAdapter(httpContext);
            if (httpSession.IsAuthenticated)
            {
                SetHttpContextUser(httpContext, httpSession);
                return true;
            }
            else
            {
                return false;
            }            
        }

        private static IHttpSessionAdapter GetHttpSessionAdapter(HttpContextBase httpContext)
        {
            return HttpSessionAdapter.Deserialize(httpContext.Session);
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