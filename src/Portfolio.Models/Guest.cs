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
        /// A guest is never authenticated.
        /// </summary>
        public override bool IsAuthenticated
        {
            get { return false; }
        }
    }
}
