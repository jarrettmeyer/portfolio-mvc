using System;
using System.Linq;
using NHibernate.Linq;
using Portfolio.Data;
using Portfolio.Data.Models;

namespace Portfolio
{
    public class TestBootstrapper
    {
        private const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=Portfolio_test;Integrated Security=true;";

        public static string ConnectionString
        {
            get { return CONNECTION_STRING; }
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

        public static void DeleteAllCategories()
        {
            using (var session = NHibernateConfig.SessionFactory.OpenSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var allCategories = session.Query<Category>().ToList();
                    foreach (var c in allCategories)
                    {
                        session.Delete(c);
                    }
                    txn.Commit();
                }
            }
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

        public static Status InsertNewStatus(string id = "TEST", string description = "Test Status", bool isCompleted = false)
        {
            var status = new Status
                         {
                             Id = id,
                             Description = description,
                             IsCompleted = isCompleted
                         };
            return InsertNewRecord(status);
        }

        public static StatusWorkflow InsertNewStatusWorkflow(Status fromStatus, Status toStatus)
        {
            var statusWorkflow = new StatusWorkflow
                                 {
                                     FromStatus = fromStatus,
                                     ToStatus = toStatus,
                                     CreatedAt = DateTime.Now
                                 };
            return InsertNewRecord(statusWorkflow);
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
