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

        public string Category
        {
            get
            {
                if (task.Category != null)
                    return task.Category.Description;

                return "";
            }
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

        public string Title
        {
            get { return task.Title; }
        }
    }
}