using System;

namespace Portfolio.Lib
{
    public static class DateTimeExtensions
    {
        public static long ToEpoch(this DateTime dateTime)
        {
            TimeSpan dateDiff = dateTime - new DateTime(1970, 1, 1, 0, 0, 0);
            long milliseconds = (long)dateDiff.TotalMilliseconds;
            return milliseconds;
        }

        public static long? ToEpoch(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToEpoch() : (long?)null;
        }
    }
}
