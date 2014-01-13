using FluentAssertions;
using NUnit.Framework;

namespace Portfolio.Lib.Caching
{
    [TestFixture]
    public class AspNetHttpCache_Tests
    {
        private ICache cache;

        [SetUp]
        public void Before_each_test()
        {
            cache = new AspNetHttpCache();
        }

        [TearDown]
        public void After_each_test()
        {
            cache.Clear();
        }

        [Test]
        public void Can_add_a_value_to_the_cache()
        {
            AddMessageToCache();
            Assert.Pass();
        }

        [Test]
        public void Can_get_a_value_from_the_cache()
        {
            AddMessageToCache();
            var message = cache.Get("message") as string;
            message.Should().Be("Hello, World!");
        }

        [Test]
        public void Clearing_the_cache_removes_all_values()
        {
            AddMessageToCache();
            cache.Clear();
            var message = cache.Get("message");
            message.Should().BeNull();
        }

        private void AddMessageToCache()
        {
            cache.Add("message", "Hello, World!");
        }
    }
}
