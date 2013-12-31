using System;
using System.Diagnostics.Contracts;

namespace Portfolio.API.Results
{
    public class ErrorDef
    {
        public ErrorDef() { }

        public ErrorDef(Exception exception)
        {
            Contract.Requires<ArgumentNullException>(exception != null);
            this.Message = exception.Message;
        }

        public string Message { get; set; }
    }
}