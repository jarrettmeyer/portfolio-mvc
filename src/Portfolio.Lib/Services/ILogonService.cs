using Portfolio.Lib.DTOs;

namespace Portfolio.Lib.Services
{
    public interface ILogonService
    {
        LogonResult Logon(CredentialsDTO credentials);
    }
}