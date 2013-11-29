using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Portfolio.Lib.Data;
using Portfolio.Lib.Services;
using Portfolio.Models;

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

            IHttpSessionAdapter sessionAdapter = HttpSessionAdapter.Deserialize(httpContext.Session);
            if (sessionAdapter.IsAuthenticated)
            {
                var repository = ServiceLocator.Instance.GetService<IRepository>();
                var user = repository.Load<User>(sessionAdapter.Username);
                httpContext.User = new GenericPrincipal(user, new string[] {});
                return true;
            }
            else
            {
                return false;
            }            
        }
    }
}