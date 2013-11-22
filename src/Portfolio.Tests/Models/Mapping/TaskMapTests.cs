using System;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using NHibernate;
using NUnit.Framework;
using Portfolio.Lib.Data;

namespace Portfolio.Models.Mapping
{
    [TestFixture]
    public class TaskMapTests
    {
        private Category category;
        private ISession session;
        private Task task;
        private int taskId;

        [SetUp]
        public void Before_each_test()
        {
            NHibernateConfig.ConnectionString = TestBootstrapper.ConnectionString;
        }

        [TearDown]
        public void After_each_test()
        {
            TestBootstrapper.DeleteAll<Task>();
            TestBootstrapper.DeleteAll<Category>();
        }

        [Test]
        public void Can_insert_a_new_task()
        {
            using (session = NHibernateConfig.SessionFactory.OpenSession())
            {
                task = new Task
                           {
                               Title = "Test Task",
                               Description = string.Format("This is a test {0}", DateTime.Now.Ticks),
                               IsCompleted = false,
                               CreatedAt = DateTime.UtcNow,
                               UpdatedAt = DateTime.UtcNow
                           };
                session.Save(task);
                session.Flush();
                Debug.WriteLine("Inserted new Task. ID: {0}", task.Id);
                Assert.True(task.Id > 0);
            }
        }

        [Test]
        public void Can_insert_a_new_task_with_a_category()
        {
            using (session = NHibernateConfig.SessionFactory.OpenSession())
            {
                category = new Category { Description = "Test", IsActive = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow };
                session.Save(category);
                session.Flush();
            }

            using (session = NHibernateConfig.SessionFactory.OpenSession())
            {
                task = new Task { Title = "Test", Description = "This is a test", IsCompleted = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow };
                task.Categories.Add(category);
                session.Save(task);
                session.Flush();
                taskId = task.Id;
            }

            using (session = NHibernateConfig.SessionFactory.OpenSession())
            {
                task = session.Load<Task>(taskId);
                task.Categories.Should().NotBeNull();
                task.Categories.Count.Should().Be(1);
                task.Categories.First().Description.Should().Be("Test");
            }
        }
    }
}
