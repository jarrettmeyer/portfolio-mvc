using System;
using System.Security.Principal;

namespace Portfolio.Models
{
    public class User : IVersionedEntity, IIdentity
    {
        /// <summary>
        /// Gets the ID for the user. This value is set by the database.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// The username for the user.
        /// </summary>
        public virtual string Username { get; set; }

        /// <summary>
        /// A hashed representation of the password for the user.
        /// </summary>
        public virtual string HashedPassword { get; set; }        

        /// <summary>
        /// Gets and sets the last time the user logged on. A null value indicates that the
        /// user has never logged on.
        /// </summary>
        public virtual DateTime? LastLogonAt { get; set; }

        /// <summary>
        /// When the user was created.
        /// </summary>
        public virtual DateTime CreatedAt { get; set; }

        /// <summary>
        /// When the user was last updated.
        /// </summary>
        public virtual DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets the rowversion for the user. This value is set by the database.
        /// </summary>
        public virtual byte[] Version { get; set; }

        /// <summary>
        /// Authentication type is part if the IIdentity interface. Any string
        /// will do here.
        /// </summary>
        public string AuthenticationType
        {
            get { return "Application"; }
        }

        /// <summary>
        /// A user is authenticated if it has an ID in the database.
        /// </summary>
        public virtual bool IsAuthenticated
        {
            get { return Id > 0; }
        }

        /// <summary>
        /// Alias for username property. This property is required by the IIdentity interface.
        /// </summary>
        public virtual string Name
        {
            get { return Username; }
        }
    }
}
