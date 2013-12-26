using System;
using System.Linq;
using System.Linq.Expressions;

namespace Portfolio.Lib.Data
{
    public abstract class Repository : IRepository
    {
        public abstract void Add<T>(T entity);

        public abstract ITransactionAdapter BeginTransaction();

        public abstract void Delete<T>(T entity);
        
        public abstract IQueryable<T> Find<T>(Expression<Func<T, bool>> expression, int? pageIndex = null, int? pageSize = null);
        
        public abstract IQueryable<T> FindAll<T>(int? pageIndex = null, int? pageSize = null);
        
        public abstract T FindOne<T>(Expression<Func<T, bool>> expression);
        
        public abstract T Load<T>(object id);

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                OnDisposing();
                GC.SuppressFinalize(this);
            }
        }

        protected abstract void OnDisposing();
    }
}