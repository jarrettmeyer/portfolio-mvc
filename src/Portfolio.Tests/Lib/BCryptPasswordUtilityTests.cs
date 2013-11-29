using System.Diagnostics;
using FluentAssertions;
using NUnit.Framework;

namespace Portfolio.Lib
{
    [TestFixture]
    public class BCryptPasswordUtilityTests
    {
        private IPasswordUtility passwordUtility;

        [SetUp]
        public void Before_each_test()
        {
            passwordUtility = new BCryptPasswordUtility();
        }

        [Test]
        [TestCase("s3cr3t", "$2a$10$nwLE7ZilHRXaKQq2TXVD4erJDZO6T66hpzYCdwMEp22PCGpaUSAzK", Result = true)]
        public bool CompareText_returns_expected_result(string plainText, string hashedText)
        {
            bool isValid = passwordUtility.CompareText(plainText, hashedText);
            return isValid;
        }

        [Test]        
        public void HashText_teturns_expected_result()
        {
            Debug.WriteLine("Password: " + passwordUtility.HashText("password"));

            string hashedText = passwordUtility.HashText("s3cr3t");
            hashedText.Length.Should().Be(60);
            hashedText.Substring(0, 7).Should().Be("$2a$10$");
        }
    }
}
