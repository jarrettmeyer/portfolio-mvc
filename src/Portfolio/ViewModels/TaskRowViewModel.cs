using System;
using System.Linq;
using Portfolio.Models;

namespace Portfolio.ViewModels
{
    public class TaskRowViewModel
    {
        public TaskRowViewModel(Task task)
        {
            Description = task.Description;
            DueOn = task.DueOn.HasValue ? task.DueOn.Value.ToShortDateString() : "None";
            HasDueDate = task.DueOn.HasValue;
            Id = task.Id;
            IsCompleted = task.IsCompleted;
            IsPastDue = task.DueOn.HasValue && !task.IsCompleted && task.DueOn.Value < DateTime.Today;
            ShowCompleteButton = !task.IsCompleted;
            Tags = task.Tags.Select(tag => new TagLabelViewModel(tag.Description, tag.Slug)).ToArray();
            Title = task.Title;
        }

        public string Description { get; set; }        

        public string DueOn { get; set; }        

        public bool HasDueDate { get; set; }

        public int Id { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsPastDue { get; set; }

        public bool ShowCompleteButton { get; set; }

        public TagLabelViewModel[] Tags { get; set; }

        public string Title { get; set; }        
    }
}