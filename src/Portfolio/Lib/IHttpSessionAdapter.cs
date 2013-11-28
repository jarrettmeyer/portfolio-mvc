using System;

namespace Portfolio.Lib
{
    public interface IHttpSessionAdapter
    {
        DateTime? CreatedAt { get; set; }

        string SessionId { get; }

        string Username { get; set; }
    }
}