using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Portfolio.Data
{
    public interface IRepository
    {
        IEnumerable<T> All<T>();
            
        T Load<T>(object id);

        IEnumerable<T> Where<T>(Expression<Func<T, bool>> expression);
    }
}
