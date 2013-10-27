using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Portfolio.Data.Models;
using Portfolio.Data.Queries;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Lib.Actions
{
    public class GetNewTaskView : ActionResult
    {
        private IEnumerable<Category> categories;
        private readonly FetchAllCategories fetchAllCategories;
        private readonly TaskInputModel form;

        public GetNewTaskView(FetchAllCategories fetchAllCategories)
        {
            this.fetchAllCategories = fetchAllCategories;            
            form = new TaskInputModel();
        }

        public override void ExecuteResult(ControllerContext context)
        {
            categories = fetchAllCategories.ExecuteQuery();
            form.Categories = categories.ToDictionary(c => c.Id, c => c.Description);        

            var viewResult = new ViewResultBuilder()
                .Controller(context.Controller)
                .ViewName("New")
                .Model(form)
                .ViewResult;
            viewResult.ExecuteResult(context);
        }
    }
}