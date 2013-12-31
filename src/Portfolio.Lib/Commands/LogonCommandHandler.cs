using Portfolio.Lib.Data;
using Portfolio.Lib.Logging;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Commands
{
    public class LogonCommandHandler : ICommandHandler<LogonCommand, LogonResult>
    {
        private LogonResult logonResult;
        private static readonly ILogWriter logWriter = Log.For<LogonCommandHandler>();
        private readonly IPasswordUtility passwordUtility;
        private readonly IRepository repository;
        private User user;

        public LogonCommandHandler(IRepository repository, IPasswordUtility passwordUtility)
        {
            this.repository = repository;
            this.passwordUtility = passwordUtility;
        }

        public LogonResult Handle(LogonCommand command)
        {
            return Logon(command);
        }

        public LogonResult Logon(LogonCommand credentials)
        {
            using (var transaction = repository.BeginTransaction())
            {
                FetchUser(credentials);
                ValidateCredentials(credentials);
                transaction.Commit();
                return logonResult;
            }            
        }

        private void FetchUser(LogonCommand credentials)
        {
            user = repository.FindOne<User>(u => u.Username == credentials.Username);
            if (user == null)
            {
                logWriter.WriteWarning("No user found. Username: {0}", credentials.Username);
            }
        }

        private bool IsValidCredentials(LogonCommand credentials)
        {
            bool isValidCredentials = user != null && passwordUtility.CompareText(credentials.PlainTextPassword, user.HashedPassword);
            if (isValidCredentials)
            {
                logWriter.WriteInfo("Logon successful. Username: {0}", credentials.Username);
            }
            else
            {
                logWriter.WriteWarning("Logon failed. Username: {0}", credentials.Username);
            }
            return isValidCredentials;
        }

        private void SetSuccessfulLogonResult()
        {
            user.LastLogonAt = Clock.Instance.Now;
            user.UpdatedAt = Clock.Instance.Now;
            logonResult = new LogonResult
            {
                IsSuccessful = true,
                User = user
            };
        }

        private void SetUnsuccessfulLogonResult()
        {
            logonResult = new LogonResult
            {
                IsSuccessful = false,
                User = new Guest()
            };
        }

        private void ValidateCredentials(LogonCommand credentials)
        {
            if (IsValidCredentials(credentials))
            {
                SetSuccessfulLogonResult();
            }
            else
            {
                SetUnsuccessfulLogonResult();
            }
        }

        
    }
}