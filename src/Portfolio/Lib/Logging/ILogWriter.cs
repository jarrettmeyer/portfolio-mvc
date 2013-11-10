using System;

namespace Portfolio.Web.Lib.Logging
{
    public interface ILogWriter
    {
        void WriteDebug(string message);
        void WriteError(string message);
        void WriteError(string message, Exception exception);
    }
}
