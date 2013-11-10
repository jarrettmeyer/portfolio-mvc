﻿using System;

namespace Portfolio.Common
{
    public class SystemClock : IClock
    {
        public DateTime Now
        {
            get { return DateTime.UtcNow; }
        }
    }
}
