using System;
using FluentAssertions;
using NUnit.Framework;

namespace Portfolio.Lib
{
    [TestFixture]
    public class Clock_Tests
    {
        [TearDown]
        public void After_each_test()
        {
            Clock.Instance = null;
        }

        [Test]
        public void Instance_can_be_set()
        {
            var clock = new JunkClock();
            Clock.Instance = clock;
            Clock.Instance.Should().BeSameAs(clock);
        }

        [Test]
        public void Instance_returns_a_system_clock_by_default()
        {
            Clock.Instance.Should().BeOfType<SystemClock>();
        }

        internal class JunkClock : Clock
        {
            public override DateTime Now
            {
                get { throw new NotImplementedException(); }
            }
        }
    }
}
