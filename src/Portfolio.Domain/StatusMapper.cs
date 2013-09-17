using System;
using Portfolio.Data.Models;
using Portfolio.Domain.ViewModels;

namespace Portfolio.Domain
{
    public class StatusMapper
    {
        public static StatusViewModel Map(Status status)
        {
            if (status == null)
                throw new ArgumentNullException("status");

            return new StatusViewModel
                   {
                       Description = status.Description ?? "",
                       Id = status.Id
                   };
        }
    }
}
