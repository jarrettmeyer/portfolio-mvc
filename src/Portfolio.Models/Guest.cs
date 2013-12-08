using System;

namespace Portfolio.Models
{
    public class Guest : User
    {
        public override string Username
        {
            get { return "Guest"; }
            set { throw new NotImplementedException("Unable to set the Username property for a guest"); }
        }

        /// <summary>
        /// Guests don't have any roles in this application.
        /// </summary>
        public override bool IsInRole(string role)
        {
            return false;
        }
    }
}
