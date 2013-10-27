using Portfolio.Data.Models;

namespace Portfolio.Web.ViewModels
{
    public class TaskRowViewModel
    {
        private readonly Task task;

        public TaskRowViewModel(Task task)
        {
            this.task = task;
        }

        public string Description
        {
            get { return task.Description ?? ""; }
        }

        public string DueOn
        {
            get
            {
                return task.DueOn.HasValue ? task.DueOn.Value.ToShortDateString() : "";
            }
        }

        public int Id
        {
            get { return task.Id; }
        }

        public string Status
        {
            get { return task.CurrentStatus.Description; }
        }
    }
}