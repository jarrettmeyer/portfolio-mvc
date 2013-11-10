using Portfolio.Lib.Data;
using Portfolio.Web.Models;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Lib.Actions
{
    public class GetTaskShowView : AbstractAction
    {
        private int id;
        private readonly IRepository repository;
        private Task task;
        private TaskViewModel viewModel;

        public GetTaskShowView(IRepository repository)
        {
            this.repository = repository;
        }

        public TaskViewModel ViewModel
        {
            get { return viewModel; }
        }

        public override void Execute()
        {
            task = repository.Load<Task>(id);
            viewModel = TaskViewModel.ForTask(task);
        }

        public GetTaskShowView ForId(int id)
        {
            this.id = id;
            return this;
        }
    }
}