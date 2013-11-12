using System;
using System.Web.Mvc;
using Portfolio.Lib;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public abstract class ApplicationController : Controller
    {
        private ActionResolver actionResolver;
        private FlashMessageCollection flashMessages;

        public virtual ActionResolver ActionResolver
        {
            get { return actionResolver ?? (actionResolver = ActionResolver.Instance); }
            set { actionResolver = value; }
        }

        public virtual FlashMessageCollection FlashMessages
        {
            get { return flashMessages ?? (flashMessages = new FlashMessageCollection(TempData)); }
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
