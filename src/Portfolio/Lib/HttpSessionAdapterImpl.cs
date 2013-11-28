using System;
using System.Web;

namespace Portfolio.Lib
{
    public class HttpSessionAdapterImpl : HttpSessionAdapter
    {
        private readonly HttpSessionStateBase sessionState;

        public HttpSessionAdapterImpl(HttpSessionStateBase sessionState)
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

        public override string Username
        {
            get { return GetValue<string>("Username", null); }
            set { sessionState["Username"] = value; }
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