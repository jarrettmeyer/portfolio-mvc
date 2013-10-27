using System.Web.Mvc;
using Portfolio.Data.Models;
using Portfolio.Data.Queries;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Lib.Actions
{
    public class GetTaskShowView : ActionResult
    {
        private readonly FetchTaskById fetchTaskById;
        private int id;
        private Task task;
        private TaskViewModel viewModel;

        public GetTaskShowView(FetchTaskById fetchTaskById)
        {
            this.fetchTaskById = fetchTaskById;            
        }

        public override void ExecuteResult(ControllerContext context)
        {
            task = fetchTaskById.ExecuteQuery(id);
            viewModel = TaskViewModel.ForTask(task);

            var viewResult = new ViewResultBuilder()
                .Controller(context.Controller)
                .ViewName("Show")
                .Model(viewModel)
                .ViewResult;

            viewResult.ExecuteResult(context);
        }

        public GetTaskShowView ForId(int id)
        {
            this.id = id;
            return this;
        }
    }
}