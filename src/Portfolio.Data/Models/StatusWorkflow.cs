using System;

namespace Portfolio.Data.Models
{
    public class StatusWorkflow : IVersionedEntity
    {
        public int Id { get; set; }
        public Status FromStatus { get; set; }
        public Status ToStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public byte[] Version { get; set; }
    }
}
