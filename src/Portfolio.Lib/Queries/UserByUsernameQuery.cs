using Portfolio.Lib.Models;

namespace Portfolio.Lib.Queries
{
    public class UserByUsernameQuery : IQuery<User>
    {
        public UserByUsernameQuery() { }

        public UserByUsernameQuery(string username)
        {
            this.Username = username;
        }

        public string Username { get; set; }
    }
}
