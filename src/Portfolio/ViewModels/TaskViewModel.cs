using Portfolio.Common;
using Portfolio.Models;
using Portfolio.Web.Models;

namespace Portfolio.Web.ViewModels
{
    public class TaskViewModel
    {
        private readonly Task task;

        public TaskViewModel(Task task)
        {
            Ensure.ArgumentIsNotNull(task, "task");
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
                if (task.DueOn.HasValue)
                {
                    return task.DueOn.Value.ToShortDateString();
                }
                return "";
            }
        }

        public int Id
        {
            get { return task.Id; }
        }

        public string Title
        {
            get { return string.Format("Task Details: {0}", task.Title); }            
        }

        public static TaskViewModel ForTask(Task task)
        {
            return new TaskViewModel(task);
        }
    }
}