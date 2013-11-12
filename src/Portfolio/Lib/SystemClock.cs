using System;

namespace Portfolio.Lib
{
    public class SystemClock : IClock
    {
        public DateTime Now
        {
            get { return DateTime.UtcNow; }
        }
    }
}
