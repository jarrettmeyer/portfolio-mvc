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
    }
}
