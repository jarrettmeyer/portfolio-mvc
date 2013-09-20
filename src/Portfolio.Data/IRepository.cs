using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Portfolio.Data
{
    public interface IRepository
    {
        void Add<T>(T entity);

        IEnumerable<T> All<T>();

        T First<T>(Expression<Func<T, bool>> expression);

        T Load<T>(object id);

        IEnumerable<T> Where<T>(Expression<Func<T, bool>> expression);
    }
}
