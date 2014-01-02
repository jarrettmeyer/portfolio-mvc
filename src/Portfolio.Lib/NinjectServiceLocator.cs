using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace Portfolio.Lib
{
    public class NinjectServiceLocator : IServiceLocator
    {
        private readonly IKernel kernel;

        public NinjectServiceLocator(IKernel kernel)
        {
            Contract.Requires<ArgumentNullException>(kernel != null);
            this.kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public object GetInstance(Type serviceType)
        {
            return kernel.Get(serviceType);            
        }

        public object GetInstance(Type serviceType, string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public TService GetInstance<TService>()
        {
            return kernel.Get<TService>();            
        }

        public TService GetInstance<TService>(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return kernel.GetAll<TService>();            
        }
    }
}