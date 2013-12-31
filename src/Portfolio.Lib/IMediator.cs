using Portfolio.Lib.Commands;
using Portfolio.Lib.Queries;

namespace Portfolio.Lib
{
    public interface IMediator
    {
        TResult Request<TResult>(IQuery<TResult> query);

        TResult Send<TResult>(ICommand<TResult> command);
    }
}
