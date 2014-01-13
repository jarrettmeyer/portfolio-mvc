using System;
using FluentAssertions;
using NUnit.Framework;

namespace Portfolio.Lib.Models
{
    [TestFixture] 
    public class Guest_Tests
    {
        private User user;

        [Test]
        public void IsInRole_is_always_false()
        {
            user = new Guest();
            user.IsInRole("anything").Should().BeFalse();
        }

        [Test]
        public void Username_is_guest()
        {
            user = new Guest();
            user.Username.Should().Be("Guest");
        }

        [Test]
        public void Username_set_accessor_throws_exception()
        {
            user = new Guest();
            Action action = () =>
            {
                user.Username = "Mike";
            };
            action.ShouldThrow<NotImplementedException>();
        }
    }
}
