using FluentAssertions;
using NUnit.Framework;

namespace Portfolio.Models
{
    [TestFixture]
    public class PasswordTokenTests
    {
        private PasswordToken passwordToken;

        [Test]
        public void Can_generate_a_new_token()
        {
            passwordToken = PasswordToken.GenerateForUser(new User());
            passwordToken.Token.Length.Should().Be(32);
        }
    }
}
