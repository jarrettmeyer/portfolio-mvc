using System;

namespace Portfolio.Lib
{
    public class SystemClock : Clock
    {
        public override DateTime Now
        {
            get { return DateTime.UtcNow; }
        }
    }
}
