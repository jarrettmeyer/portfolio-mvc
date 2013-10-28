using System.Collections.Generic;
using System.Linq;
using Portfolio.Data.Models;
using Portfolio.Data.Queries;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Lib.Actions
{
    public class GetNewTaskView : AbstractAction
    {
        private IEnumerable<Category> categories;
        private readonly FetchAllCategories fetchAllCategories;
        private readonly TaskInputModel form;

        public GetNewTaskView(FetchAllCategories fetchAllCategories)
        {
            this.fetchAllCategories = fetchAllCategories;            
            form = new TaskInputModel();
        }

        public TaskInputModel Form
        {
            get { return form; }
        }

        public override void Execute()
        {
            categories = fetchAllCategories.ExecuteQuery();
            form.Categories = categories.ToDictionary(c => c.Id, c => c.Description);
        }
    }
}