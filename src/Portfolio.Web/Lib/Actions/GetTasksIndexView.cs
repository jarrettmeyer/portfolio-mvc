using System.Collections.Generic;
using Portfolio.Data.Models;
using Portfolio.Data.Queries;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Lib.Actions
{
    public class GetTasksIndexView : AbstractAction
    {
        private TaskListViewModel viewModel;
        private readonly FetchAllTasks query;
        private IEnumerable<Task> tasks;

        public GetTasksIndexView(FetchAllTasks query)
        {
            this.query = query;
        }

        public TaskListViewModel ViewModel
        {
            get { return viewModel; }
        }

        public override void Execute()
        {
            GetViewModel();            
        }

        private void GetViewModel()
        {
            tasks = query.ExecuteQuery();
            viewModel = new TaskListViewModel(tasks);
        }

        protected override void OnDisposing()
        {
            if (query != null)
            {
                query.Dispose();
            }
        }
    }
}