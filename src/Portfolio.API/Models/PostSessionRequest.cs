using Portfolio.Lib.Commands;

namespace Portfolio.API.Models
{
    public class PostSessionRequest
    {
        public string Password { get; set; }

        public string Username { get; set; }

        public LogonCommand ToLogonCommand()
        {
            return new LogonCommand
            {
                PlainTextPassword = Password,
                Username = Username
            };
        }
    }
}