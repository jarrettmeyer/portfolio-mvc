﻿using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    public interface ILogonService
    {
        LogonResult Logon(Credentials credentials);
    }
}