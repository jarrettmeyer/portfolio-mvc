using System;
using System.Web.Mvc;

namespace Portfolio.Web.Lib.Actions
{
    public abstract class AbstractAction : IAction
    {
        private Func<ActionResult> onError;
        private Func<ActionResult> onSuccess;

        protected AbstractAction()
        {
            onError = () => new EmptyResult();
            onSuccess = () => new EmptyResult();
        }

        public Func<ActionResult> OnError
        {
            get { return ReturnActionResultOrEmpty(onError); }
            set { onError = value; }
        }

        public Func<ActionResult> OnSuccess
        {
            get { return ReturnActionResultOrEmpty(onSuccess); }
            set { onSuccess = value; }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public abstract void Execute();

        public virtual IAction WithErrorAction(Func<ActionResult> onError)
        {
            this.onError = onError;
            return this;
        }

        public virtual IAction WithSuccessAction(Func<ActionResult> onSuccess)
        {
            this.onSuccess = onSuccess;
            return this;
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposing)
                OnDisposing();
        }

        protected virtual void OnDisposing()
        {
            
        }

        private Func<ActionResult> ReturnActionResultOrEmpty(Func<ActionResult> actionResultDelegate)
        {
            if (actionResultDelegate == null)
                return () => new EmptyResult();

            return actionResultDelegate;
        }
    }
}