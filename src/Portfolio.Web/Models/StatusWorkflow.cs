using System;

namespace Portfolio.Web.Models
{
    public class StatusWorkflow : IVersionedEntity
    {
        public virtual int Id { get; set; }
        public virtual Status FromStatus { get; set; }
        public virtual Status ToStatus { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
