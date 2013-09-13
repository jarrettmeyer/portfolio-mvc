using System;

namespace Portfolio.Data.Commands
{
    public abstract class AbstractCommand : ICommand
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

        public abstract void ExecuteCommand();

        protected virtual void OnDisposing() { }
    }
}
