using System.Collections.Generic;

namespace Portfolio.Domain.ViewModels
{
    public class WorkflowViewModel
    {
        public StatusViewModel Status { get; set; }

        public IEnumerable<StatusViewModel> Workflows { get; set; }
    }
}
