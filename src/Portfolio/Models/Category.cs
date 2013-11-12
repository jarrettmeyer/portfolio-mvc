using System;
using Portfolio.Web.Models;

namespace Portfolio.Models
{
    /// <summary>
    /// The category for a task.
    /// </summary>
    public class Category : IVersionedEntity
    {
        /// <summary>
        /// The category ID. This is an identity that will be assigned 
        /// by the database.        
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// The category description.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Indicates if the category is active.
        /// </summary>
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// When the category was created.
        /// </summary>
        public virtual DateTime CreatedAt { get; set; }

        /// <summary>
        /// When the category was updated.
        /// </summary>
        public virtual DateTime UpdatedAt { get; set; }
        
        /// <summary>
        /// The category version. This will be assigned by the database.
        /// </summary>
        public virtual byte[] Version { get; set; }
    }
}
