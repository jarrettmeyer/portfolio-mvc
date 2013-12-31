using Portfolio.Lib.Commands;

namespace Portfolio.API.ApiModels
{
    public class PostSessionRequest
    {
        public string Password { get; set; }

        public string Username { get; set; }

        public LogonCommand ToCommand()
        {
            return new LogonCommand
            {
                PlainTextPassword = Password,
                Username = Username
            };
        }
    }
}