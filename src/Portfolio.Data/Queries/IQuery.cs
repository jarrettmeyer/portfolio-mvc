using System;

namespace Portfolio.Data.Queries
{
    public interface IQuery : IDisposable
    {
        object ExecuteQuery();
    }

    public interface IQuery<out TResult>
    {
        TResult ExecuteQuery();
    }
}
