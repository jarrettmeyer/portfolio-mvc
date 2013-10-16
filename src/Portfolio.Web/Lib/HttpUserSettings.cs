using System;
using System.Web;
using Portfolio.Common;

namespace Portfolio.Web.Lib
{
    public class HttpUserSettings : IUserSettings
    {
        private readonly HttpContextBase context;

        public HttpUserSettings(HttpContextBase context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            this.context = context;
        }

        public string IPAddress
        {
            get { return context.Request.UserHostAddress; }
        }
    }
}