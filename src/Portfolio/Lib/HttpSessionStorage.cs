using System;
using System.Web;
using Portfolio.Common;

namespace Portfolio.Web.Lib
{
    public class HttpSessionStorage
    {
        private readonly HttpSessionStateBase httpSession;

        private HttpSessionStorage(HttpSessionStateBase httpSession)
        {
            Ensure.ArgumentIsNotNull(httpSession, "httpSession");
            this.httpSession = httpSession;
        }

        public DateTime CreatedAt
        {
            get
            {
                object createdAt = httpSession["CreatedAt"];
                if (createdAt == null)
                {
                    createdAt = DateTime.UtcNow;
                    httpSession["CreatedAt"] = createdAt;
                }
                return (DateTime)createdAt;
            }
        }

        public string SessionID
        {
            get { return httpSession.SessionID; }
        }

        public static HttpSessionStorage Deserialize(HttpSessionStateBase httpSession)
        {
            return new HttpSessionStorage(httpSession);
        }
    }
}