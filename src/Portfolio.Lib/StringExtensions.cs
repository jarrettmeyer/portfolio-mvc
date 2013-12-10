using System;

namespace Portfolio.Lib
{
    public static class StringExtensions
    {
        public static DateTime? SafeParseDateTime(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            DateTime dateTime;
            bool isSuccessful = DateTime.TryParse(value, out dateTime);
            return (isSuccessful) ? dateTime : (DateTime?)null;
        }
    }
}
