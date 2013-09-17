using System;
using NUnit.Framework;

namespace Portfolio.Data.Models
{
    [TestFixture]
    public class StatusMapTests
    {
        [SetUp]
        public void before_each_test()
        {
            NHibernateConfig.ConnectionString = TestBootstrapper.ConnectionString;
        }

        [TearDown]
        public void after_each_test()
        {
            TestBootstrapper.DeleteAll<Status>();
        }

        [Test]
        public void can_insert_a_status()
        {
            var id = string.Format("TEST{0}", DateTime.Now.Ticks);
            var description = string.Format("Testing {0}", DateTime.Now.Ticks);
            TestBootstrapper.InsertNewStatus(id, description, false);

            using (var session = NHibernateConfig.SessionFactory.OpenSession())
            {
                var status = session.Load<Status>(id);
                Assert.AreEqual(description, status.Description);
            }
        }
    }
}
