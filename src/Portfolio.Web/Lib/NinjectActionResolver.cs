using Ninject;
using Portfolio.Common;

namespace Portfolio.Web.Lib
{
    public class NinjectActionResolver : ActionResolver
    {
        private readonly IKernel kernel;

        public NinjectActionResolver(IKernel kernel)
        {
            Ensure.ArgumentIsNotNull(kernel, "kernel");
            this.kernel = kernel;
        }

        public override TActionResult GetAction<TActionResult>()
        {
            var actionResult = kernel.Get<TActionResult>();
            return actionResult;
        }
    }
}