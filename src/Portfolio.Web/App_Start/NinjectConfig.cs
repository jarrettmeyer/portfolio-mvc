using NHibernate;
using Ninject;
using Portfolio.Data;
using Portfolio.Domain.Services;
using Portfolio.Domain.Services.Impl;

namespace Portfolio.Web
{
    public class NinjectConfig
    {
        public static void RegisterServices(IKernel kernel)
        {
            // Data layer bindings
            kernel.Bind<ISessionFactory>().ToConstant(NHibernateConfig.SessionFactory).InSingletonScope();
            kernel.Bind<ISession>().ToMethod(ctx => ctx.Kernel.Get<ISessionFactory>().OpenSession());
            kernel.Bind<IRepository>().To<NHibernateRepository>();

            // Service layer bindings
            kernel.Bind<IWorkflowService>().To<WorkflowServiceImpl>();
        }
    }
}