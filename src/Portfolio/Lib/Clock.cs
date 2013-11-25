using System;

namespace Portfolio.Lib
{
    public abstract class Clock : IClock
    {
        private static volatile IClock instance;

        public static IClock Instance
        {
            get { return instance ?? (instance = new SystemClock()); }
            set { instance = value; }
        }
        public abstract DateTime Now { get; }
    }
}