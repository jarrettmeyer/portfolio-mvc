using System.Globalization;
using NUnit.Framework;
using Portfolio.Properties;

namespace Portfolio
{
    [TestFixture]
    public class FrameworkTests
    {
        [Test]
        public void Can_get_a_resource_that_exists()
        {
            var value = Resources.ResourceManager.GetString("TestString", CultureInfo.CurrentCulture);
            Assert.AreEqual("Hello, World!", value);
        }

        [Test]
        public void Resources_that_do_not_exist_return_null()
        {
            var value = Resources.ResourceManager.GetString("this_string_does_not_exist", CultureInfo.CurrentCulture);
            Assert.IsNull(value);
        }
    }
}
