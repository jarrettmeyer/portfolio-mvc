using System;
using NUnit.Framework;
using Portfolio.Lib.Data;
using Portfolio.Web.Models;

namespace Portfolio.Data.Models
{
    [TestFixture]
    public class StatusWorkflowMapTests
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
        public void has_expected_from_to_mapping()
        {
            var fromStatus = TestBootstrapper.InsertNewStatus("FROM", "From Status", false);
            var toStatus1 = TestBootstrapper.InsertNewStatus("TO_1", "To Status 1", false);
            var toStatus2 = TestBootstrapper.InsertNewStatus("TO_2", "To Status 2", false);

            var workflow1 = InsertWorkflow(fromStatus, toStatus1);
            var workflow2 = InsertWorkflow(fromStatus, toStatus2);

            Assert.True(workflow1.Id > 0);
            Assert.True(workflow2.Id > workflow1.Id);
        }

        private StatusWorkflow InsertWorkflow(Status from, Status to)
        {
            var workflow = new StatusWorkflow
                           {
                               FromStatus = from,
                               ToStatus = to,
                               CreatedAt = DateTime.Now
                           };
            using (var session = NHibernateConfig.SessionFactory.OpenSession())
            {
                session.Save(workflow);
                session.Flush();
            }
            return workflow;
        }
    }
}
