using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Portfolio.Data.Models;
using Portfolio.Data.Queries;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Lib.Actions
{
    public class GetTasksIndexView : ActionResult, IDisposable
    {
        private TaskListViewModel model;
        private readonly FetchAllTasks query;
        private IEnumerable<Task> tasks;

        public GetTasksIndexView(FetchAllTasks query)
        {
            this.query = query;
        }

        public void Dispose()
        {
            if (query != null)
                query.Dispose();

            GC.SuppressFinalize(this);
        }

        public override void ExecuteResult(ControllerContext context)
        {
            GetViewModel();
            GenerateResult(context);
        }

        private void GenerateResult(ControllerContext context)
        {
            var viewResult = new ViewResultBuilder()
                .Controller(context.Controller)
                .Model(model)
                .ViewResult;
            viewResult.ExecuteResult(context);
        }

        private void GetViewModel()
        {
            tasks = query.ExecuteQuery();
            model = new TaskListViewModel(tasks);
        }
    }
}