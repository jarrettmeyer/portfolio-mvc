using Portfolio.Models;

namespace Portfolio.ViewModels
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

        public string Title
        {
            get { return task.Title; }
        }
    }
}