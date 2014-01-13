using System;
using FluentAssertions;
using NUnit.Framework;
using Portfolio.Lib.Models;

namespace Portfolio.Lib
{
    [TestFixture]
    public class ApplicationIdentity_Tests
    {
        [Test]
        public void AuthenticationType_has_expected_value()
        {
            var applicationIdentity = CreateNewApplicationIdentity();
            applicationIdentity.AuthenticationType.Should().Be("ApplicationIdentity");
        }

        [Test]
        public void IsAuthenticated_returns_false_for_guests()
        {
            var applicationIdentity = CreateNewGuestApplicationIdentity();
            applicationIdentity.IsAuthenticated.Should().BeFalse();
        }

        [Test]
        public void IsAuthenticated_returns_true_for_users()
        {
            var applicationIdentity = CreateNewApplicationIdentity();
            applicationIdentity.IsAuthenticated.Should().BeTrue();
        }

        [Test]
        public void It_can_be_instantiated()
        {
            var applicationIdentity = CreateNewApplicationIdentity();
            applicationIdentity.Should().BeOfType<ApplicationIdentity>();
        }

        [Test]
        public void It_throws_an_exception_if_the_user_is_null()
        {
            Action action = () =>
            {
                new ApplicationIdentity(null);
            };
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void Name_returns_expected_value()
        {
            var applicationIdentity = CreateNewApplicationIdentity("Bob");
            applicationIdentity.Name.Should().Be("Bob");
        }

        private static ApplicationIdentity CreateNewApplicationIdentity(string username = "tester")
        {
            var user = new User
            {
                Username = username
            };
            return new ApplicationIdentity(user);
        }
        
        private static ApplicationIdentity CreateNewGuestApplicationIdentity()
        {
            var user = new Guest();
            return new ApplicationIdentity(user);
        }
    }
}
