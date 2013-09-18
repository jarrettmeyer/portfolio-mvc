using System.Web.Mvc;
using Portfolio.Domain.Services;

namespace Portfolio.Web.Controllers
{
    public class WorkflowsController : ApplicationController
    {
        private readonly IWorkflowService workflowService;
 
        public WorkflowsController(IWorkflowService workflowService)
        {
            this.workflowService = workflowService;
        }

        public ActionResult Index()
        {
            //var model = workflowService.GetWorkflowForStatus()
            return Json(new { }, JsonRequestBehavior.AllowGet);            
        }

        public ActionResult Show(string status)
        {
            var model = workflowService.GetWorkflowForStatus(status);
            return Json(model, JsonRequestBehavior.AllowGet);            
        }
    }
}
