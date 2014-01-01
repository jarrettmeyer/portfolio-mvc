using NHibernate;
using Portfolio.Lib.Logging;
using Portfolio.Lib.Models;
using Portfolio.Lib.Queries;

namespace Portfolio.Lib.Commands
{
    public class LogonCommandHandler : ICommandHandler<LogonCommand, LogonResult>
    {
        private LogonResult logonResult;
        private static readonly ILogWriter logWriter = Log.For<LogonCommandHandler>();
        private readonly IMediator mediator;
        private readonly IPasswordUtility passwordUtility;
        private readonly ISession session;
        private User user;

        public LogonCommandHandler(ISession session, IMediator mediator, IPasswordUtility passwordUtility)
        {
            this.session = session;
            this.mediator = mediator;
            this.passwordUtility = passwordUtility;
        }

        public LogonResult Handle(LogonCommand command)
        {
            using (var transaction = session.BeginTransaction())
            {
                FetchUser(command);
                ValidateCredentials(command);
                transaction.Commit();
                return logonResult;
            }
        }

        private void FetchUser(LogonCommand credentials)
        {
            user = mediator.Request(new UserByUsernameQuery(credentials.Username));
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