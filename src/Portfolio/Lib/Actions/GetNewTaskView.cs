using Portfolio.Lib.Data;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Lib.Actions
{
    public class GetNewTaskView : AbstractAction
    {
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