using System;
using Ninject;

namespace Portfolio.Lib.Services
{
    public class NinjectServiceLocator : ServiceLocator
    {
        private readonly IKernel kernel;

        public NinjectServiceLocator(IKernel kernel)
        {
            if (kernel == null)
                throw new ArgumentNullException("kernel");

            this.kernel = kernel;
        }

        public override TService GetService<TService>()
        {
            return kernel.Get<TService>();
        }
    }
}