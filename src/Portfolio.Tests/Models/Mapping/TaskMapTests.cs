using System;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using NHibernate;
using NUnit.Framework;
using Portfolio.Lib.Data;
using Portfolio.Lib.Models;

namespace Portfolio.Models.Mapping
{
    [TestFixture]
    public class TaskMapTests
    {
        private Tag tag;
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
            TestBootstrapper.DeleteAll<Tag>();
        }

        [Test]
        public void Can_insert_a_new_task()
        {
            using (session = NHibernateConfig.SessionFactory.OpenSession())
            {
                task = ObjectMother.NewTask;;
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
                tag = ObjectMother.NewTag;
                tag.Description = "Test";
                session.Save(tag);
                session.Flush();
            }

            using (session = NHibernateConfig.SessionFactory.OpenSession())
            {
                task = ObjectMother.NewTask;
                task.Tags.Add(tag);
                session.Save(task);
                session.Flush();
                taskId = task.Id;
            }

            using (session = NHibernateConfig.SessionFactory.OpenSession())
            {
                task = session.Load<Task>(taskId);
                task.Tags.Should().NotBeNull();
                task.Tags.Count.Should().Be(1);
                task.Tags.First().Description.Should().Be("Test");
            }
        }
    }
}
