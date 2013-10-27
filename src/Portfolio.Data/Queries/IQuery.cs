using System;

namespace Portfolio.Data.Queries
{
    public interface IQuery<out TResult> : IDisposable
    {
        TResult ExecuteQuery();
    }

    public interface IQuery<in TParams, out TResult> : IDisposable
    {
        TResult ExecuteQuery(TParams parameters);
    }
}
