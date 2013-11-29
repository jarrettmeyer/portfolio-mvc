using Portfolio.Lib.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    public class LogonServiceImpl : ILogonService
    {
        private LogonResult logonResult;
        private readonly IPasswordUtility passwordUtility;
        private readonly IRepository repository;
        private User user;

        public LogonServiceImpl(IRepository repository, IPasswordUtility passwordUtility)
        {
            this.repository = repository;
            this.passwordUtility = passwordUtility;
        }

        public LogonResult Logon(Credentials credentials)
        {
            using (var transaction = repository.BeginTransaction())
            {
                FetchUser(credentials);
                ValidateCredentials(credentials);
                transaction.Commit();
                return logonResult;
            }            
        }

        private void FetchUser(Credentials credentials)
        {
            user = repository.FindOne<User>(u => u.Username == credentials.Username);
        }

        private bool IsValidCredentials(Credentials credentials)
        {
            return user != null && passwordUtility.CompareText(credentials.Password, user.HashedPassword);
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

        private void ValidateCredentials(Credentials credentials)
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