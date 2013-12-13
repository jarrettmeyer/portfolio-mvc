using System;

namespace Portfolio.Lib
{
    public static class DateTimeExtensions
    {
        public static int ToEpoch(this DateTime dateTime)
        {
            TimeSpan dateDiff = dateTime - new DateTime(1970, 1, 1, 0, 0, 0);
            int seconds = (int)dateDiff.TotalSeconds;
            return seconds;
        }
    }
}
