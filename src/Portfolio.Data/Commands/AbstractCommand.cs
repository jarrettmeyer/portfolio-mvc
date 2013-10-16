using System;

namespace Portfolio.Data.Commands
{
    public abstract class AbstractCommand<TInput, TResult> : ICommand<TInput, TResult>
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

        public abstract TResult ExecuteCommand(TInput input);

        protected virtual void OnDisposing() { }
    }
}
