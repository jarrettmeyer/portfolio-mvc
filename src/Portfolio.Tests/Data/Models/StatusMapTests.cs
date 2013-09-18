using System;
using System.Linq;
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
            TestBootstrapper.DeleteAll<StatusWorkflow>();
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

        [Test]
        public void status_should_have_workflows()
        {
            var status001 = TestBootstrapper.InsertNewStatus("TEST001", "Test 001");
            var status002 = TestBootstrapper.InsertNewStatus("TEST002", "Test 001");
            var status003 = TestBootstrapper.InsertNewStatus("TEST003", "Test 001");
            TestBootstrapper.InsertNewStatusWorkflow(status001, status002);
            TestBootstrapper.InsertNewStatusWorkflow(status001, status003);

            using (var session = NHibernateConfig.SessionFactory.OpenSession())
            {
                var status = session.Load<Status>("TEST001");
                var ids = status.Workflows.Select(w => w.ToStatus.Id).ToArray();
                Assert.AreEqual(2, status.Workflows.Count);
                Assert.IsTrue(ids.Contains("TEST002"));
                Assert.IsTrue(ids.Contains("TEST003"));
            }
        }

        [Test]
        public void workflows_is_empty_when_fetched_from_database()
        {
            var testStatus = TestBootstrapper.InsertNewStatus();
            using (var session = NHibernateConfig.SessionFactory.OpenSession())
            {
                var status = session.Load<Status>(testStatus.Id);
                Assert.IsNotNull(status.Workflows);
                Assert.IsEmpty(status.Workflows);
            }
        }
    }
}
