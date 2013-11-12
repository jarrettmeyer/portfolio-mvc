using System;
using System.Collections.Generic;
using Portfolio.Web.Models;

namespace Portfolio.Models
{
    public class Task : IVersionedEntity
    {
        public Task()
        {
            Statuses = new List<TaskStatus>();
        }

        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual Category Category { get; set; }
        public virtual Status CurrentStatus { get; set; }
        public virtual DateTime? DueOn { get; set; }
        public virtual bool IsCompleted { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime UpdatedAt { get; set; }
        public virtual byte[] Version { get; set; }

        public virtual IList<TaskStatus> Statuses { get; set; }

        public virtual void AddStatus(TaskStatus status)
        {
            if (status == null)
                throw new ArgumentNullException("status");

            status.Task = this;
            Statuses.Add(status);
        }
    }
}
