using System.Web;
using Portfolio.Lib;
using Portfolio.Models;

namespace Portfolio.ViewModels
{
    public class TaskViewModel
    {        
        public TaskViewModel()
        {
        }

        public TaskViewModel(Task task)
        {
            Ensure.ArgumentIsNotNull(task, "task");

            Description = new HtmlTextFormatter().FormatText(task.Description);
            DueOn = task.DueOn.HasValue ? task.DueOn.Value.ToShortDateString() : "None";
            Id = task.Id;
            Title = task.Title;
        }

        public IHtmlString Description { get; set; }

        public string DueOn { get; set; }        

        public int Id { get; set; }        

        public string Title { get; set; }
    }
}