using System;

namespace Portfolio.Data.Models
{
    public class TaskStatus : IVersionedEntity
    {
        public virtual int Id { get; set; }
        public virtual Task Task { get; set; }
        public virtual string Status { get; set; }
        public virtual bool IsCompleted { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
