using System;
using log4net;

namespace Portfolio.Lib.Logging
{
    public class Log4NetLogWriter : ILogWriter
    {
        private readonly ILog log;

        public Log4NetLogWriter(Type type)
        {
            log = LogManager.GetLogger(type);
        }

        public void WriteDebug(string message)
        {
            log.Debug(message);
        }

        public void WriteDebug(string format, params object[] args)
        {
            var message = string.Format(format, args);
            WriteDebug(message);
        }

        public void WriteError(string message)
        {
            log.Error(message);
        }

        public void WriteError(string message, Exception exception)
        {
            log.Error(message, exception);
        }

        public void WriteInfo(string message)
        {
            log.Info(message);
        }

        public void WriteInfo(string format, params object[] args)
        {
            var message = string.Format(format, args);
            WriteInfo(message);
        }

        public void WriteWarning(string message)
        {
            log.Warn(message);
        }

        public void WriteWarning(string format, params object[] args)
        {
            var message = string.Format(format, args);
            WriteWarning(message);
        }
    }
}
