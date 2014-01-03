using System;
using System.Diagnostics.Contracts;

namespace Portfolio.API.Models
{
    public class ErrorDef
    {
        public ErrorDef() { }

        public ErrorDef(string message)
        {
            Contract.Requires<ArgumentNullException>(message != null);
            this.Message = message;
        }

        public ErrorDef(Exception exception)
            : this(exception.Message)
        {
            Contract.Requires<ArgumentNullException>(exception != null);
        }

        public string Message { get; set; }
    }
}