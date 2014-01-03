using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Portfolio.Lib;

namespace Portfolio.API.Models
{
    public class ApiResult<TData> where TData : class
    {
        private readonly IList<ErrorDef> errors = new List<ErrorDef>();        

        public ApiResult(bool isSuccessful = true)
        {            
            this.IsSuccessful = isSuccessful;
        }

        public ApiResult(TData data, bool isSuccessful = true)
        {
            Contract.Requires<ArgumentNullException>(data != null);
            this.Data = data;
            this.IsSuccessful = isSuccessful;
        }

        public TData Data { get; set; }        

        public ErrorDef[] Errors
        {
            get
            {
                // If there are any errors, then return an array of errors. Otherwise,
                // return null. This makes the JSON result a lot easier to work with
                // from inside the client.
                //
                // if (result.errors) {
                //   app.handleErrors(result.errors);
                // }
                if (errors.Any())
                    return errors.ToArray();
                return null;
            }
        }

        public bool IsSuccessful { get; set; }

        public long Timestamp
        {
            get { return DateTime.UtcNow.ToEpoch(); }
        }

        public void AddError(ErrorDef error)
        {
            errors.Add(error);
        }
    }
}