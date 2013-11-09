using System;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;

namespace Portfolio.Data
{
    public class NHibernateRepository : IRepository
    {
        private readonly ISession session;

        public NHibernateRepository(ISession session)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            this.session = session;
        }

        public void Add<T>(T entity)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(entity);
                transaction.Commit();
            }
        }

        public IQueryable<T> Find<T>(Expression<Func<T, bool>> expression, int? pageIndex = null, int? pageSize = null)
        {
            var items = session.Query<T>().Where(expression);
            if (pageIndex == null || pageSize == null)
                return items;

            return ApplyPagingToQueryable(items, pageIndex.Value, pageSize.Value);
        }

        public IQueryable<T> FindAll<T>(int? pageIndex = null, int? pageSize = null)
        {
            var items = session.Query<T>();
            if (pageIndex == null || pageSize == null)
                return items;

            return ApplyPagingToQueryable(items, pageIndex.Value, pageSize.Value);
        }

        public T FindOne<T>(Expression<Func<T, bool>> expression)
        {
            var item = session.Query<T>().Where(expression).FirstOrDefault();
            return item;
        }

        public T Load<T>(object id)
        {
            var item = session.Load<T>(id);
            return item;
        }

        public void SaveChanges()
        {
            using (var transaction = session.BeginTransaction())
            {
                transaction.Commit();
            }
        }
        
        private static IQueryable<T> ApplyPagingToQueryable<T>(IQueryable<T> items, int pageIndex, int pageSize)
        {
            int startIndex = pageIndex * pageSize;
            items = items.Skip(startIndex).Take(pageSize);
            return items;
        }
    }
}
