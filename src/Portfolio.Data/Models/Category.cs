using System;

namespace Portfolio.Data.Models
{
    public class Category : IVersionedEntity
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime UpdatedAt { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
