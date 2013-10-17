using System;

namespace Portfolio.Common
{
    public interface IClock
    {
        DateTime Now { get; }
    }
}
