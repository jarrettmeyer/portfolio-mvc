using System.Web;
using NHibernate;
using Ninject;
using Portfolio.Lib;
using Portfolio.Lib.Data;
using Portfolio.Lib.Services;

namespace Portfolio.App_Start
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
            kernel.Bind<HttpRequestBase>().ToMethod(ctx => ctx.Kernel.Get<HttpContextBase>().Request);
            kernel.Bind<ITagCreationService>().To<TagCreationServiceImpl>();
            kernel.Bind<ITagDeletionService>().To<TagDeletionServiceImpl>();
            kernel.Bind<ITagUpdateService>().To<TagUpdateServiceImpl>();
            kernel.Bind<ITaskCompletionService>().To<TaskCompletionServiceImpl>();
            kernel.Bind<ITaskCreationService>().To<TaskCreationServiceImpl>();

            // Web layer and generic service bindings
            kernel.Bind<IClock>().To<SystemClock>();

            ConfigureSingletonInstances(kernel);
        }

        private static void ConfigureSingletonInstances(IKernel kernel)
        {            
            ServiceLocator.Instance = new NinjectServiceLocator(kernel);
        }
    }
}