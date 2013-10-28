using Portfolio.Data.Models;
using Portfolio.Data.Queries;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Lib.Actions
{
    public class GetTaskShowView : AbstractAction
    {
        private readonly FetchTaskById fetchTaskById;
        private int id;
        private Task task;
        private TaskViewModel viewModel;

        public GetTaskShowView(FetchTaskById fetchTaskById)
        {
            this.fetchTaskById = fetchTaskById;            
        }

        public TaskViewModel ViewModel
        {
            get { return viewModel; }
        }

        public override void Execute()
        {
            task = fetchTaskById.ExecuteQuery(id);
            viewModel = TaskViewModel.ForTask(task);
        }

        public GetTaskShowView ForId(int id)
        {
            this.id = id;
            return this;
        }
    }
}