using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Portfolio.Data
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

        IEnumerable<T> All<T>();

        T First<T>(Expression<Func<T, bool>> expression);

        T Load<T>(object id);

        void SaveChanges();

        IEnumerable<T> Where<T>(Expression<Func<T, bool>> expression);
    }
}
