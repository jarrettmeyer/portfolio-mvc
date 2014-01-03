using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;
using Ninject;

namespace Portfolio.API.App_Start
{
    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            Contract.Requires(kernel != null);
        }        

        public IDependencyScope BeginScope()
        {
            return this;            
        }
    }
}