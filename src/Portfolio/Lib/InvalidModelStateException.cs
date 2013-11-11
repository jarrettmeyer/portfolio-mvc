using System;
using System.Web.Mvc;

namespace Portfolio.Lib
{
    public class InvalidModelStateException : Exception
    {
        private readonly string message;
        private readonly ModelStateDictionary modelState;

        public InvalidModelStateException(string message, ModelStateDictionary modelState)
        {
            this.message = message;
            this.modelState = modelState;
        }

        public override string Message
        {
            get { return message; }
        }

        public virtual ModelStateDictionary ModelState
        {
            get { return modelState; }
        }
    }
}