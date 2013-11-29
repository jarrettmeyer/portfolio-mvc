using System;

namespace Portfolio.Models
{
    public class Guest : User
    {
        public override int Id
        {
            get { return 0; }
            set { throw new NotImplementedException("Unable to set the ID property for a guest"); }
        }

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
