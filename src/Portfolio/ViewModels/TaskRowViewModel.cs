using System;
using System.Linq;
using System.Web;
using Portfolio.Lib;
using Portfolio.Models;

namespace Portfolio.ViewModels
{
    public class TaskRowViewModel
    {
        public TaskRowViewModel(Task task)
        {
            Description = new HtmlTextFormatter().FormatText(task.Description);
            DueOn = task.DueOn.HasValue ? task.DueOn.Value.ToShortDateString() : "None";
            HasDueDate = task.DueOn.HasValue;
            Id = task.Id;
            IsCompleted = task.IsCompleted;
            IsDueToday = !task.IsCompleted && task.DueOn.HasValue && task.DueOn.Value == DateTime.Today;
            IsPastDue = !task.IsCompleted && task.DueOn.HasValue && task.DueOn.Value < DateTime.Today;
            ShowCompleteButton = !task.IsCompleted;
            Tags = task.Tags.Select(tag => new TagViewModel(tag)).ToArray();
            Title = task.Title;
        }

        public IHtmlString Description { get; set; }

        public string DueOn { get; set; }        

        public bool HasDueDate { get; set; }

        public int Id { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsDueToday { get; set; }

        public bool IsPastDue { get; set; }

        public bool ShowCompleteButton { get; set; }

        public TagViewModel[] Tags { get; set; }

        public string Title { get; set; }        
    }
}