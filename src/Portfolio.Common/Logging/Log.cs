using System;
using Portfolio.Common.Logging.Impl;

namespace Portfolio.Common.Logging
{
    public static class Log
    {
        public static ILogWriter For<T>()
        {
            return new Log4NetLogWriter(typeof(T));
        }

        public static ILogWriter For(Type type)
        {
            return new Log4NetLogWriter(type);
        }
    }
}
