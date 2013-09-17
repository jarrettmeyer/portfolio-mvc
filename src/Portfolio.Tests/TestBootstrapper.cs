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
            using (var session = NHibernateConfig.SessionFactory.OpenSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var category = new Category
                                   {
                                       Description = description,
                                       CreatedAt = DateTime.UtcNow,
                                       UpdatedAt = DateTime.UtcNow
                                   };
                    session.Save(category);
                    txn.Commit();
                    return category;
                }
            }
        }
    }
}
