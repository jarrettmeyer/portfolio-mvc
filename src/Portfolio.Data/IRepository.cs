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

        void SaveChanges();

        IEnumerable<T> Where<T>(Expression<Func<T, bool>> expression);
    }
}
