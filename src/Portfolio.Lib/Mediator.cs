using Portfolio.Lib.Commands;
using Portfolio.Lib.Queries;

namespace Portfolio.Lib
{
    public abstract class Mediator : IMediator
    {
        private static volatile IMediator instance;

        public static IMediator Instance
        {
            get { return instance; }
            set { instance = value; }
        }
        public abstract TResult Request<TResult>(IQuery<TResult> query);

        public abstract TResult Send<TResult>(ICommand<TResult> command);
    }
}
