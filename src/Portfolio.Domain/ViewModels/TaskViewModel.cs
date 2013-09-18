using System;

namespace Portfolio.Domain.ViewModels
{
    public class TaskViewModel
    {
        public CategoryViewModel Category { get; set; }

        public StatusViewModel CurrentStatus { get; set; }

        public string Description { get; set; }

        public DateTime? DueOn { get; set; }

        public bool HasDueDate
        {
            get { return DueOn.HasValue; }
        }

        public int Id { get; set; }

        public bool IsCompleted { get; set; }

        public StatusViewModel Status { get; set; }
    }
}
