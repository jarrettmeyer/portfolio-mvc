using System;

namespace Portfolio.Web.Lib.Queries
{
    public abstract class AbstractQuery<TResult> : IQuery<TResult>
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                OnDisposing();
            }
        }

        public abstract TResult ExecuteQuery();

        protected virtual void OnDisposing() { }
    }

    public abstract class AbstractQuery<TParam, TResult> : IQuery<TParam, TResult>
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                OnDisposing();
            }
        }

        public abstract TResult ExecuteQuery(TParam parameters);

        protected virtual void OnDisposing() { }
    }
}
