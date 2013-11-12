using System.Collections.Generic;
using System.Linq;
using Portfolio.Models;

namespace Portfolio.Lib.Rules
{
    /// <summary>
    /// This implementation of the workflow validator pulls all workflows into memory. Even for
    /// a very large application, you'd never have more than 100 workflows, so this is going to
    /// be a relatively small object at all times.
    /// </summary>
    public class WorkflowValidatorImpl : IWorkflowValidator
    {
        private readonly IEnumerable<StatusWorkflow> workflows;

        public WorkflowValidatorImpl(IEnumerable<StatusWorkflow> workflows)
        {
            this.workflows = workflows ?? new StatusWorkflow[] { };
        }

        public bool IsValidTransition(string fromStatus, string toStatus)
        {
            bool isValid = workflows.Any(w => w.FromStatus.Id == fromStatus && w.ToStatus.Id == toStatus);
            return isValid;
        }
    }
}
