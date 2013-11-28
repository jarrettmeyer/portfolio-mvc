using System;
using System.Web.Mvc;
using Portfolio.Lib;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public abstract class ApplicationController : Controller
    {
        public const string DEFAULT_FORM_ERROR_MESSAGE = "There is something wrong with the form. Please correct the errors and try again.";

        private FlashMessageCollection flashMessages;
        private IHttpSessionAdapter sessionAdapter;

        public virtual FlashMessageCollection FlashMessages
        {
            get { return flashMessages ?? (flashMessages = new FlashMessageCollection(TempData)); }
        }

        public virtual IHttpSessionAdapter SessionAdapter
        {
            get { return sessionAdapter ?? (sessionAdapter = HttpSessionAdapter.Deserialize(Session)); }
            set { sessionAdapter = value; }
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

        protected override void OnException(ExceptionContext exceptionContext)
        {
            InvalidModelStateException exception = exceptionContext.Exception as InvalidModelStateException;
            if (exception != null)
            {
                // Mark the exception as handled to keep the error from bubbling to IIS.
                exceptionContext.ExceptionHandled = true;
                HandleInvalidModelState(exception);
            }
        }
    }
}
