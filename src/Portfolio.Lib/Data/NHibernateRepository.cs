using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Exceptions;
using NHibernate.Linq;

namespace Portfolio.Lib.Data
{
    public class NHibernateRepository : Repository
    {
        private readonly ISession session;

        public NHibernateRepository(ISession session)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            this.session = session;
        }

        public override void Add<T>(T entity)
        {
            try
            {
                session.Save(entity);
            }
            catch (GenericADOException ex)
            {
                SqlException sqlException = ex.InnerException as SqlException;
                if (sqlException != null && new Regex("^Cannot insert duplicate key row in object").IsMatch(ex.InnerException.Message))
                {
                    throw new UniqueRecordViolationException(sqlException);
                }
                throw;
            }
            catch (NonUniqueObjectException ex)
            {
                throw new UniqueRecordViolationException(ex);
                //throw;
            }
        }

        public override ITransactionAdapter BeginTransaction()
        {
            return new NHibernateTransactionAdapter(session.BeginTransaction());
        }

        public override void Delete<T>(T entity)
        {
            session.Delete(entity);
        }

        public override IQueryable<T> Find<T>(Expression<Func<T, bool>> expression, int? pageIndex = null, int? pageSize = null)
        {
            var items = session.Query<T>().Where(expression);
            if (pageIndex == null || pageSize == null)
                return items;

            return ApplyPagingToQueryable(items, pageIndex.Value, pageSize.Value);
        }

        public override IQueryable<T> FindAll<T>(int? pageIndex = null, int? pageSize = null)
        {
            var items = session.Query<T>();
            if (pageIndex == null || pageSize == null)
                return items;

            return ApplyPagingToQueryable(items, pageIndex.Value, pageSize.Value);
        }

        public override T FindOne<T>(Expression<Func<T, bool>> expression)
        {
            var item = session.Query<T>().Where(expression).FirstOrDefault();
            return item;
        }

        public override T Load<T>(object id)
        {
            var item = session.Load<T>(id);
            return item;
        }

        protected override void OnDisposing()
        {
            if (session != null)
            {
                session.Dispose();
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
