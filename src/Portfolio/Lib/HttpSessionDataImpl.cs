using System;
using System.Web;

namespace Portfolio.Lib
{
    public class HttpSessionDataImpl : HttpSessionData
    {
        private readonly HttpSessionStateBase sessionState;

        public HttpSessionDataImpl(HttpSessionStateBase sessionState)
        {
            Ensure.ArgumentIsNotNull(sessionState, "sessionState");
            this.sessionState = sessionState;
        }

        public override DateTime? CreatedAt
        {
            get { return GetValue<DateTime?>("CreatedAt", DateTime.Now); }
            set { sessionState["CreatedAt"] = value; }
        }

        public override string SessionId
        {
            get { return sessionState.SessionID; }
        }

        private T GetValue<T>(string key, T defaultValue = default (T))
        {
            try
            {
                object sessionObject = sessionState[key];
                return (T)sessionObject;
            }
            catch (Exception)
            {
                return defaultValue;                
            }
        }
    }
}