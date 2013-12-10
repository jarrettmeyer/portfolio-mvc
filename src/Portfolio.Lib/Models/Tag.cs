using System;

namespace Portfolio.Lib.Models
{
    /// <summary>
    /// The category for a task.
    /// </summary>
    public class Tag : IVersionedEntity<int>
    {
        /// <summary>
        /// The tag ID. This is an identity that will be assigned 
        /// by the database.        
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// The URL-friendly slug for the tag. This column should be
        /// unique.
        /// </summary>
        public virtual string Slug { get; set; }

        /// <summary>
        /// The tag description.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Indicates if the tag is active.
        /// </summary>
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// When the tag was created.
        /// </summary>
        public virtual DateTime CreatedAt { get; set; }

        /// <summary>
        /// When the tag was updated.
        /// </summary>
        public virtual DateTime UpdatedAt { get; set; }
        
        /// <summary>
        /// The tag version. This will be assigned by the database.
        /// </summary>
        public virtual byte[] Version { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Tag)obj);
        }

        protected bool Equals(Tag other)
        {
            return Id == other.Id && string.Equals(Slug, other.Slug, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id * 397) ^ (Slug != null ? Slug.GetHashCode() : 0);
            }
        }
    }
}
