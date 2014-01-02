using System.Linq;
using NHibernate;
using NHibernate.Linq;
using NUnit.Framework;
using Portfolio.Lib.Data;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Queries
{
    [TestFixture]
    public class TasksByTagQueryHandlerTests
    {
        private TasksByTagQuery query;
        private IQueryHandler<TasksByTagQuery, TaskCollection> queryHandler;
        private ISession session;
            
        [SetUp]
        public void Before_each_test()
        {
            NHibernateConfig.ConnectionString = TestBootstrapper.ConnectionString;
            using (session = NHibernateConfig.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    SaveNewTag("alpha");
                    SaveNewTag("bravo");

                    SaveNewTask("alpha");
                    SaveNewTask("alpha");
                    SaveNewTask("alpha");
                    SaveNewTask("bravo");
                    SaveNewTask("bravo");

                    transaction.Commit();                    
                }
            }

            session = NHibernateConfig.SessionFactory.OpenSession();
            queryHandler = new TasksByTagQueryHandler(session);
            query = new TasksByTagQuery();
        }

        [TearDown]
        public void After_each_test()
        {
            TestBootstrapper.DeleteAll<Task>();
            TestBootstrapper.DeleteAll<Tag>();
        }
        

        [Test]
        public void Handler_returns_expected_result()
        {
            query.Tagged = "alpha";
            var result = queryHandler.Handle(query);
            Assert.AreEqual(3, result.Count());
            Assert.IsTrue(result.All(task => task.Tags.Any(tag => tag.Slug == "alpha")));
        }

        private void SaveNewTag(string slug)
        {
            Tag tag = ObjectMother.NewTag;
            tag.Slug = slug;
            tag.Description = slug;
            session.Save(tag);
        }

        private void SaveNewTask(string slug)
        {
            Task task = ObjectMother.NewTask;
            var tag = session.Query<Tag>().First(t => t.Slug == slug);
            task.AddTag(tag);
            session.Save(task);
        }
    }
}
