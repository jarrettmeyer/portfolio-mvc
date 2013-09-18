using System;
using System.Collections.Generic;
using System.Linq;
using Portfolio.Common.Logging;
using Portfolio.Data;
using Portfolio.Data.Models;
using Portfolio.Domain.ViewModels;

namespace Portfolio.Domain.Services.Impl
{
    public class WorkflowServiceImpl : IWorkflowService
    {
        private IEnumerable<Status> allStatuses;
        private IRepository repository;

        public WorkflowServiceImpl(IRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            this.repository = repository;
        }

        public WorkflowViewModel GetWorkflowForStatus(string status)
        {       
            if (string.IsNullOrEmpty(status))
                throw new ArgumentException("Cannot get status entry for null or empty value.", "status");

            Log.For<WorkflowServiceImpl>().WriteDebug(string.Format("Gettting workflow status for '{0}'.", status));

            GetAllStatuses();

            var targetStatus = allStatuses.First(s => s.Id == status);            
            var workflowStatuses = repository.Where<StatusWorkflow>(w => w.FromStatus.Id == status).Select(w => w.ToStatus).ToArray();            

            var workflowViewModel = new WorkflowViewModel
                                    {
                                        Status = StatusMapper.Map(targetStatus),
                                        Workflows = workflowStatuses.Select(x => StatusMapper.Map(x))
                                    };
            return workflowViewModel;
        }

        private void GetAllStatuses()
        {
            allStatuses = repository.All<Status>();
        }
    }
}
