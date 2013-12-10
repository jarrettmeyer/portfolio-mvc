using System;
using System.Security.Principal;
using Portfolio.Lib.Models;

namespace Portfolio.Lib
{
    public class ApplicationIdentity : IIdentity
    {
        private readonly User user;

        public ApplicationIdentity(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            this.user = user;
        }

        public string Name
        {
            get { return user.Username; }
        }

        public string AuthenticationType
        {
            get { return typeof(ApplicationIdentity).Name; }
        }

        public bool IsAuthenticated
        {
            get { return !(user is Guest); }
        }
    }
}
