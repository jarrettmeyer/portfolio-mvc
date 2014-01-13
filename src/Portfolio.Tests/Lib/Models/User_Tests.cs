using FluentAssertions;
using NUnit.Framework;

namespace Portfolio.Lib.Models
{
    [TestFixture]
    public class User_Tests
    {
        private User user;

        [Test]
        public void IsInRole_returns_true()
        {
            user = new User();
            user.IsInRole("anything").Should().BeTrue();
        }
    }
}
