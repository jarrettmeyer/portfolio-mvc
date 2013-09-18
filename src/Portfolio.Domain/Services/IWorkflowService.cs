using Portfolio.Domain.ViewModels;

namespace Portfolio.Domain.Services
{
    public interface IWorkflowService
    {
        WorkflowViewModel GetWorkflowForStatus(string status);
    }
}
