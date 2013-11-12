using System;
using System.Web.Mvc;

namespace Portfolio.Lib
{
    public class InvalidModelStateException : Exception
    {
        private readonly string message;
        private readonly ModelStateDictionary modelState;
        private readonly Func<ActionResult> onInvalidModelState; 

        public InvalidModelStateException(string message, ModelStateDictionary modelState, Func<ActionResult> onInvalidModelState = null)
        {
            this.message = message;
            this.modelState = modelState;
            this.onInvalidModelState = onInvalidModelState ?? (() => new EmptyResult());
        }

        public override string Message
        {
            get { return message; }
        }

        public virtual ModelStateDictionary ModelState
        {
            get { return modelState; }
        }

        public virtual Func<ActionResult> OnInvalidModelState
        {
            get { return onInvalidModelState; }
        }
    }
}