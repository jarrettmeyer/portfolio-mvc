using System;
using System.Linq;
using System.Linq.Expressions;

namespace Portfolio.Lib.Data
{
    public abstract class Repository : IRepository
    {
        private static volatile IRepository instance;

        public static IRepository Instance
        {
            get
            {
                if (instance == null)
                    throw new NullReferenceException("Instance has not been set.");

                return instance;
            }
            set { instance = value; }
        }
        
        public abstract void Add<T>(T entity);
        
        public abstract ITransactionAdapter BeginTransaction();
        
        public abstract IQueryable<T> Find<T>(Expression<Func<T, bool>> expression, int? pageIndex = null, int? pageSize = null);
        
        public abstract IQueryable<T> FindAll<T>(int? pageIndex = null, int? pageSize = null);
        
        public abstract T FindOne<T>(Expression<Func<T, bool>> expression);
        
        public abstract T Load<T>(object id);
        
        public abstract void SaveChanges();
    }
}