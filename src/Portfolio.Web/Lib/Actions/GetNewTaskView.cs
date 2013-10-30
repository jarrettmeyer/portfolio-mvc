using System.Collections.Generic;
using Portfolio.Data;
using Portfolio.Data.Models;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Lib.Actions
{
    public class GetNewTaskView : AbstractAction
    {
        private IEnumerable<Category> categories;        
        private readonly TaskInputModel form;
        private readonly IRepository repository;

        public GetNewTaskView(IRepository repository)
        {
            this.repository = repository;
            form = new TaskInputModel();
        }

        public TaskInputModel Form
        {
            get { return form; }
        }

        public override void Execute()
        {
            CategoriesSelectList.Initialize(repository);            
        }
    }
}