using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Http.Dependencies;
using Ninject.Activation;
using Ninject.Activation.Blocks;
using Ninject.Parameters;

namespace Portfolio.API.App_Start
{
    public class NinjectDependencyScope : IDependencyScope
    {
        private readonly IActivationBlock activationBlock;

        public NinjectDependencyScope(IActivationBlock activationBlock)
        {
            Contract.Requires(activationBlock != null);
            this.activationBlock = activationBlock;
        }

        public void Dispose()
        {
            if (CanDisposeOfActivationBlock)
            {
                activationBlock.Dispose();                
            }
        }

        public object GetService(Type serviceType)
        {
            return GetServices(serviceType).FirstOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = activationBlock.CreateRequest(serviceType, null, new IParameter[] { }, true, false);
            IEnumerable<object> services = activationBlock.Resolve(request);
            return services;
        }

        private bool CanDisposeOfActivationBlock
        {
            get { return activationBlock != null && !activationBlock.IsDisposed; }
        }
    }
}