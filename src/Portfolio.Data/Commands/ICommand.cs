using System;

namespace Portfolio.Data.Commands
{
    public interface ICommand<TInput, TResult> : IDisposable
    {
        TResult ExecuteCommand(TInput input);
    }
}
