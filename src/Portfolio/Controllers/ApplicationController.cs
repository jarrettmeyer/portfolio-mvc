using System;
using System.Web.Mvc;
using Portfolio.Lib;

namespace Portfolio.Controllers
{
    public abstract class ApplicationController : Controller
    {
        private ActionResolver actionResolver;

        public virtual ActionResolver ActionResolver
        {
            get { return actionResolver ?? (actionResolver = ActionResolver.Instance); }
            set { actionResolver = value; }
        }

        protected virtual void CheckModelState(Func<ActionResult> onInvalidModelState = null)
        {
            if (!ViewData.ModelState.IsValid)
                throw new InvalidModelStateException("", ViewData.ModelState, onInvalidModelState);
        }

        protected virtual void HandleInvalidModelState(InvalidModelStateException exception)
        {
            exception.OnInvalidModelState().ExecuteResult(ControllerContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            InvalidModelStateException exception = filterContext.Exception as InvalidModelStateException;
            if (exception != null)
                HandleInvalidModelState(exception);
        }
    }
}
