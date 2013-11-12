using Ninject;
using Portfolio.Common;

namespace Portfolio.Lib
{
    public class NinjectActionResolver : ActionResolver
    {
        private readonly IKernel kernel;

        public NinjectActionResolver(IKernel kernel)
        {
            Ensure.ArgumentIsNotNull(kernel, "kernel");
            this.kernel = kernel;
        }

        public override TAction GetAction<TAction>()
        {
            var action = kernel.Get<TAction>();
            return action;
        }
    }
}