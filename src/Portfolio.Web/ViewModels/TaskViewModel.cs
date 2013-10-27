using System;
using System.Text;
using Portfolio.Data.Models;

namespace Portfolio.Web.ViewModels
{
    public class TaskViewModel
    {
        private string description;
        private DateTime? dueOn;

        public string Description
        {
            get { return description ?? ""; }            
        }

        public string DueOn
        {
            get
            {
                if (dueOn.HasValue)
                {
                    return dueOn.Value.ToShortDateString();
                }
                return "";
            }
        }

        public int Id { get; set; }

        public string Title
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append("Task Details");
                if (!string.IsNullOrEmpty(description))
                {
                    sb.Append(": ");
                    if (description.Length >= 30)
                    {
                        sb.Append(description.Substring(0, 30));
                    }
                }
                return sb.ToString();
            }
        }

        public static TaskViewModel ForTask(Task task)
        {            
            return new TaskViewModel
            {
                description = task.Description,
                dueOn = task.DueOn,
                Id = task.Id
            };            
        }
    }
}