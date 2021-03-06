﻿using System;
using System.Diagnostics.Contracts;
using System.Security.Principal;

namespace Portfolio.Lib.Models
{
    public class User : IPrincipal, IEquatable<User>
    {
        /// <summary>
        /// The unique ID for the user. This field is the primary key and set by the database.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// The username for the user.
        /// </summary>
        public virtual string Username { get; set; }

        /// <summary>
        /// A hashed representation of the password for the user.
        /// </summary>
        public virtual string HashedPassword { get; protected set; }        

        /// <summary>
        /// Gets and sets the last time the user logged on. A null value indicates that the
        /// user has never logged on.
        /// </summary>
        public virtual DateTime? LastLogonAt { get; set; }

        /// <summary>
        /// Returns true if the user is active.
        /// </summary>
        public virtual bool IsActive { get; set; }

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
        /// Ideally, we would have a 'roles' table, and this method would return true
        /// if the user had that role. There's no real need to build something like
        /// that for this demo application, so we're just going to return 'true' all
        /// the time, instead.
        /// </summary>
        public virtual bool IsInRole(string role)
        {
            return true;
        }

        public virtual void SetHashedPassword(string plainTextPassword, IPasswordUtility passwordUtility)
        {
            Contract.Requires<ArgumentNullException>(passwordUtility != null);
            this.HashedPassword = passwordUtility.HashText(plainTextPassword);
        }

        public virtual IIdentity Identity
        {
            get { return new ApplicationIdentity(this); }
        }

        public virtual bool Equals(User other)
        {
            if (other == null)
                return false;

            return Id == other.Id && string.Equals(Username, other.Username, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
