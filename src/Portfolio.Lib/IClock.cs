using System;

namespace Portfolio.Lib
{
    public interface IClock
    {
        DateTime Now { get; }
    }
}
