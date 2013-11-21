using System;
using System.Diagnostics;
using NUnit.Framework;
using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.Web.Models;

namespace Portfolio.Data.Models
{
    [TestFixture]
    public class TaskMapTests
    {
        [SetUp]
        public void before_each_test()
        {
            NHibernateConfig.ConnectionString = TestBootstrapper.ConnectionString;
        }

        [TearDown]
        public void after_each_test()
        {
            TestBootstrapper.DeleteAll<Task>();
            TestBootstrapper.DeleteAll<Category>();
        }

        [Test]
        public void can_insert_a_new_task()
        {
            var category = TestBootstrapper.InsertNewCategory();

            using (var session = NHibernateConfig.SessionFactory.OpenSession())
            {
                var task = new Task
                           {
                               Title = "Test Task",
                               Description = string.Format("This is a test {0}", DateTime.Now.Ticks),
                               //Category = category,
                               //CurrentStatus = status,
                               CreatedAt = DateTime.Now,
                               UpdatedAt = DateTime.Now
                           };
                session.Save(task);
                session.Flush();
                Debug.WriteLine("Inserted new Task. ID: {0}", task.Id);
                Assert.True(task.Id > 0);
            }
        }
    }
}
