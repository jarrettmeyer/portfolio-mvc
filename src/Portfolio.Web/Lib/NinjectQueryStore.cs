using Ninject;
using Portfolio.Data.Queries;

namespace Portfolio.Web.Lib
{
    public class NinjectQueryStore : IQueryStore
    {
        private readonly IKernel kernel;

        public NinjectQueryStore(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public TQuery GetQuery<TQuery>()
        {
            return kernel.Get<TQuery>();
        }
    }
}