using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;
using Ninject;

namespace Portfolio.API.App_Start
{
    public class NinjectDependencyScope : IDependencyScope
    {
        private readonly IKernel kernel;

        public NinjectDependencyScope(IKernel kernel)
        {
            Contract.Requires(kernel != null);
            this.kernel = kernel;
        }

        public void Dispose()
        {
            if (CanDisposeOfKernel)
            {
                kernel.Dispose();                
            }
        }

        public object GetService(Type serviceType)
        {
            var service = kernel.TryGet(serviceType);
            return service;            
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {            
            return kernel.GetAll(serviceType);
        }

        private bool CanDisposeOfKernel
        {
            get { return kernel != null && !kernel.IsDisposed; }
        }
    }
}