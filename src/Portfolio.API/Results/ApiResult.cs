using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Portfolio.Lib;

namespace Portfolio.API.Results
{
    public class ApiResult<TData> where TData : class, new()
    {
        private readonly TData data;
        private readonly IList<ErrorDef> errors = new List<ErrorDef>();
        private readonly long timestamp = DateTime.UtcNow.ToEpoch();

        public ApiResult(bool isSuccessful = true)
        {
            this.data = new TData();
            this.IsSuccessful = isSuccessful;
        }

        public ApiResult(TData data, bool isSuccessful = true)
        {
            Contract.Requires<ArgumentNullException>(data != null);
            this.data = data;
            this.IsSuccessful = isSuccessful;
        }

        public TData Data
        {
            get { return data; }
        }

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
            get { return timestamp; }
        }

        public void AddError(ErrorDef error)
        {
            errors.Add(error);
        }
    }
}