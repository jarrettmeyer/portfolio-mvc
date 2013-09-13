using System;

namespace Portfolio.Data.Queries
{
    public abstract class AbstractQuery<TResult> : IQuery<TResult>, IQuery
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                OnDisposing();
            }
        }

        object IQuery.ExecuteQuery()
        {
            return ExecuteQuery();
        }

        public abstract TResult ExecuteQuery();

        protected virtual void OnDisposing() { }
    }
}
