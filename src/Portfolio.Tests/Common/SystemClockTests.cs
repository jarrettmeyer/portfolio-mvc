using System;
using FluentAssertions;
using NUnit.Framework;

namespace Portfolio.Common
{
    [TestFixture]
    public class SystemClockTests
    {
        private IClock clock;

        [Test]
        public void Now_should_return_the_system_time()
        {
            clock = new SystemClock();
            clock.Now.Should().BeCloseTo(DateTime.UtcNow);
        }
    }
}
