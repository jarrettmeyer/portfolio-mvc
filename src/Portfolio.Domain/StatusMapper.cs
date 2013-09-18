using Portfolio.Data.Models;
using Portfolio.Domain.ViewModels;

namespace Portfolio.Domain
{
    public class StatusMapper
    {
        public static StatusViewModel Map(Status status)
        {
            var statusViewModel = new StatusViewModel();
            if (status != null)
            {
                statusViewModel.Description = status.Description;
                statusViewModel.Id = status.Id;
            }
            return statusViewModel;
        }
    }
}
