using System.Collections.Generic;
using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Actions
{
    public class GetTasksIndexView : AbstractAction
    {
        private TaskListViewModel viewModel;
        private readonly IRepository repository;
        private IEnumerable<Task> tasks;

        public GetTasksIndexView(IRepository repository)
        {
            this.repository = repository;
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
            tasks = repository.FindAll<Task>();
            viewModel = new TaskListViewModel(tasks);
        }
    }
}