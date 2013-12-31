namespace Portfolio.Lib.Commands
{
    public class LogonCommand : ICommand<LogonResult>
    {
        public LogonCommand()
        {            
        }

        public LogonCommand(string username, string plainTextPassword)
        {
            this.Username = username;
            this.PlainTextPassword = plainTextPassword;
        }

        public string PlainTextPassword { get; set; }

        public string Username { get; set; }
    }
}
