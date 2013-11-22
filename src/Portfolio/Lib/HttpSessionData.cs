using System;
using System.Web;

namespace Portfolio.Lib
{
    public abstract class HttpSessionData : IHttpSessionData
    {
        public abstract DateTime? CreatedAt { get; set; }

        public abstract string SessionId { get; }

        public static IHttpSessionData Deserialize(HttpSessionStateBase httpSession)
        {
            return new HttpSessionDataImpl(httpSession);
        }
    }
}