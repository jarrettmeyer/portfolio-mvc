using System;

namespace Portfolio.Lib
{
    public interface IHttpSessionData
    {
        DateTime? CreatedAt { get; set; }

        string SessionId { get; }
    }
}