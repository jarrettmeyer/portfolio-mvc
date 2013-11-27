using System;
using System.Collections.Generic;

namespace Portfolio.Models
{
    public class Task : IVersionedEntity
    {
        public Task()
        {
            Initialize();            
        }

        /// <summary>
        /// The task ID. This is an identity that will be assigned by
        /// the databse.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// The task title.
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// The task description.
        /// </summary>
        public virtual string Description { get; set; }
        public virtual DateTime? DueOn { get; set; }

        /// <summary>
        /// Is the task completed?
        /// </summary>
        public virtual bool IsCompleted { get; set; }

        /// <summary>
        /// The time that the task was completed.
        /// </summary>
        public virtual DateTime? CompletedAt { get; set; }

        /// <summary>
        /// When the task was created.
        /// </summary>
        public virtual DateTime CreatedAt { get; set; }

        /// <summary>
        /// When the task was last updated.
        /// </summary>
        public virtual DateTime UpdatedAt { get; set; }

        /// <summary>
        /// The task version. This will be assigned by the database.
        /// </summary>
        public virtual byte[] Version { get; set; }

        /// <summary>
        /// The list of tags appropriate for the task.
        /// </summary>
        public virtual IList<Tag> Tags { get; set; }

        private void Initialize()
        {
            Tags = new List<Tag>();
        }
    }
}
