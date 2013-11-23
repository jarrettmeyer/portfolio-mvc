using System.Linq;
using NHibernate.Linq;
using Portfolio.Lib.Data;
using Portfolio.Models;

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

        public static int DeleteAllTags()
        {
            return DeleteAll<Tag>();
        }

        public static int DeleteAllTasks()
        {
            return DeleteAll<Task>();
        }
    }
}
