using Ninject;
using Portfolio.Data.Commands;

namespace Portfolio.Web.Lib
{
    public class NinjectCommandStore : ICommandStore
    {
        private readonly IKernel kernel;

        public NinjectCommandStore(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public TCommand GetCommand<TCommand>()
        {
            return kernel.Get<TCommand>();
        }
    }
}