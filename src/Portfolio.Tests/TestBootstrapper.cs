using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Portfolio.Data.Models;
using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.Web.Models;

namespace Portfolio
{
    public class TestBootstrapper
    {
        private const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=Portfolio_test;Integrated Security=true;";

        public static string ConnectionString
        {
            get { return CONNECTION_STRING; }
        }

        /// <summary>
        /// Opens a new NHibernate <see cref="ISession"/> instance.
        /// </summary>        
        public static ISession OpenSession()
        {
            var session = NHibernateConfig.SessionFactory.OpenSession();
            return session;
        }

        public static int DeleteAll<T>()
        {
            int deletedCount = 0;
            using (var session = NHibernateConfig.SessionFactory.OpenSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var entities = session.Query<T>().ToList();
                    foreach (var e in entities)
                    {
                        session.Delete(e);
                        deletedCount += 1;
                    }
                    txn.Commit();
                }
            }
            return deletedCount;
        }

        public static int DeleteAllCategories()
        {
            return DeleteAll<Category>();
        }

        public static int DeleteAllTasks()
        {
            return DeleteAll<Task>();
        }

        public static Category InsertNewCategory(string description = "Test Category")
        {
            var category = new Category
                           {
                               Description = description,
                               CreatedAt = DateTime.UtcNow,
                               UpdatedAt = DateTime.UtcNow
                           };            
            return InsertNewRecord(category);
        }

        public static Task InsertNewTask(string description, bool isCompleted = false, DateTime? dueOn = null)
        {
            var timestamp = DateTime.Now;

            var task = new Task
            {
                Title = "Testing...",
                Description = description,
                DueOn = dueOn,
                IsCompleted = isCompleted,
                CreatedAt = timestamp,
                UpdatedAt = timestamp
            };
            return InsertNewRecord(task);            
        }

        private static T InsertNewRecord<T>(T inserted)
        {
            using (var session = NHibernateConfig.SessionFactory.OpenSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    session.Save(inserted);
                    txn.Commit();
                    return inserted;
                }
            }
        }
    }
}
