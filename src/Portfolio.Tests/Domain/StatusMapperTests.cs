using System;
using NUnit.Framework;
using Portfolio.Data.Models;

namespace Portfolio.Domain
{
    [TestFixture]
    public class StatusMapperTests
    {
        private Status status;

        [Test]
        public void maps_properties()
        {
            status = new Status
                     {
                         Id = "TEST",
                         Description = "Test Status"
                     };
            var view = StatusMapper.Map(status);
            Assert.AreEqual("TEST", view.Id);
            Assert.AreEqual("Test Status", view.Description);
        }

        [Test]
        public void throws_exception_when_status_is_null()
        {
            status = null;
            Assert.Throws<ArgumentNullException>(() => StatusMapper.Map(status));
        }
    }
}
