using System;

namespace Portfolio.Lib.Logging
{
    public interface ILogWriter
    {
        void WriteDebug(string message);
        void WriteDebug(string format, params object[] args);
        void WriteError(string message);
        void WriteError(string message, Exception exception);
        void WriteInfo(string message);
        void WriteInfo(string format, params object[] args);
        void WriteWarning(string message);
        void WriteWarning(string format, params object[] args);
    }
}
