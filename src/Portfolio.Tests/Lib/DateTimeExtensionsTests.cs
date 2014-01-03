using System;
using NUnit.Framework;

namespace Portfolio.Lib
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        [Test]
        [TestCase(2013, 12, 13, 10, 32, 45, 678, Result = 1386930765678)]
        public long ToEpoch_returns_expected_result(int year, int month, int day, int hour, int minute, int second, int ms)
        {
            var dateTime = new DateTime(year, month, day, hour, minute, second, ms);
            var epoch = dateTime.ToEpoch();
            return epoch;
        }
    }
}
