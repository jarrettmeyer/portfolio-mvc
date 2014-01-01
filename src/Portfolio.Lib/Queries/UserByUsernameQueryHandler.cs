using System;
using System.Diagnostics.Contracts;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Queries
{
    public class UserByUsernameQueryHandler : IQueryHandler<UserByUsernameQuery, User>
    {
        private readonly ISession session;

        public UserByUsernameQueryHandler(ISession session)
        {
            Contract.Requires<ArgumentNullException>(session != null);
            this.session = session;
        }

        public User Handle(UserByUsernameQuery query)
        {
            var user = session.Query<User>()
                .FirstOrDefault(u => u.Username == query.Username);
            return user;
        }
    }
}
