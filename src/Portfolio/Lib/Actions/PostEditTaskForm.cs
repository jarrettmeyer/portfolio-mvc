using Portfolio.Common;
using Portfolio.Lib.Data;
using Portfolio.Web.Models;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Lib.Actions
{
    public class PostEditTaskForm : AbstractAction
    {
        private TaskInputModel form;
        private readonly IRepository repository;
        private Task task;

        public PostEditTaskForm(IRepository repository)
        {
            this.repository = repository;
        }

        public int Id
        {
            get { return task.Id; }
        }

        public override void Execute()
        {
            task = repository.Load<Task>(form.Id);
            task.Title = form.Title;
            task.Description = form.Description;
            task.Category = GetCategory();
            task.DueOn = form.DueOn.SafeParseDateTime();
            repository.SaveChanges();
        }

        private Category GetCategory()
        {
            if (form.SelectedCategory.HasValue)
                return repository.Load<Category>(form.SelectedCategory.Value);

            return null;
        }

        public PostEditTaskForm WithForm(TaskInputModel form)
        {
            this.form = form;
            return this;
        }
    }
}