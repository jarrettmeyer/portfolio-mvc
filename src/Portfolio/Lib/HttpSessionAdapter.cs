using System;
using System.Web;

namespace Portfolio.Lib
{
    public abstract class HttpSessionAdapter : IHttpSessionAdapter
    {
        public abstract DateTime? CreatedAt { get; set; }

        public abstract string SessionId { get; }

        public abstract string Username { get; set; }

        public static IHttpSessionAdapter Deserialize(HttpSessionStateBase httpSession)
        {
            return new HttpSessionAdapterImpl(httpSession);
        }
    }
}