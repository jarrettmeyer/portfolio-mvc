using System;

namespace Portfolio.Models
{
    /// <summary>
    /// The category for a task.
    /// </summary>
    public class Tag : IVersionedEntity
    {
        /// <summary>
        /// The tag ID. This is an identity that will be assigned 
        /// by the database.        
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// The tag description.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// The URL-friendly sluf for the tag.
        /// </summary>
        public virtual string Slug { get; set; }

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
    }
}
