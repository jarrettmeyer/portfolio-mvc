using FluentAssertions;
using NUnit.Framework;

namespace Portfolio.Lib
{
    [TestFixture]
    public class BooleanExtensions_Tests
    {
        [Test]
        public void ToYesNo_returns_No_for_false()
        {
            false.ToYesNo().Should().Be("No");
        }

        [Test]
        public void ToYesNo_returns_Yes_for_true()
        {
            true.ToYesNo().Should().Be("Yes");
        }
    }
}
