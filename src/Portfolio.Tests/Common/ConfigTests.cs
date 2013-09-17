using System.Diagnostics;
using NUnit.Framework;

namespace Portfolio.Common
{
    [TestFixture]
    public class ConfigTests
    {
        [Test]
        public void can_get_config_value_from_app_settings()
        {
            string value = Config.GetConfigValue("Test_Key");
            Debug.WriteLine("Test_Key: {0}", value);
            Assert.AreEqual("Hello, World!", value);
        }

        [Test]
        public void can_get_config_value_from_environment()
        {
            string value = Config.GetConfigValue("PATH");
            Debug.WriteLine("PATH: {0}", value);
            Assert.IsNotNullOrEmpty(value);
        }

        [Test]        
        public void has_expected_config_values_for_connection_string()
        {
            string value = Config.ConnectionString;
            Assert.IsNotNullOrEmpty(value);
        }

        [Test]
        public void returns_null_if_key_does_not_exist()
        {
            string value = Config.GetConfigValue("This key should not exist");
            Assert.IsNull(value);
        }
    }
}
