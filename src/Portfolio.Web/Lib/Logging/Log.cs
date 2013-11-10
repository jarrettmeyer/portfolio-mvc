using System;
using Portfolio.Web.Lib.Logging.Impl;

namespace Portfolio.Web.Lib.Logging
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
