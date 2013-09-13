using System;

namespace Portfolio.Data.Commands
{
    public interface ICommand : IDisposable
    {
        void ExecuteCommand();
    }
}
