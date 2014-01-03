using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Activation.Blocks;

namespace Portfolio.API.App_Start
{
    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel.BeginBlock())
        {
            Contract.Requires(kernel != null);
            this.kernel = kernel;
        }        

        public IDependencyScope BeginScope()
        {
            IActivationBlock activationBlock = kernel.BeginBlock();
            return new NinjectDependencyScope(activationBlock);
        }
    }
}