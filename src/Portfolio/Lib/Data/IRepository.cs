using System;
using System.Linq;
using System.Linq.Expressions;

namespace Portfolio.Lib.Data
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// The repository should be used when the queries are simple. There are no joins to
    /// worry about, etc.
    /// </remarks>
    public interface IRepository
    {
        void Add<T>(T entity);

        ITransactionAdapter BeginTransaction();

        void Delete<T>(T entity);

        IQueryable<T> Find<T>(Expression<Func<T, bool>> expression, int? pageIndex = null, int? pageSize = null);

        IQueryable<T> FindAll<T>(int? pageIndex = null, int? pageSize = null);

        T FindOne<T>(Expression<Func<T, bool>> expression);

        T Load<T>(object id);

        void SaveChanges();
    }
}
