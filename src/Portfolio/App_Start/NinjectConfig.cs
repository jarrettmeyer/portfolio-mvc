using System.Web;
using NHibernate;
using Ninject;
using Portfolio.Common;
using Portfolio.Data.Queries;
using Portfolio.Web.Lib;
using Portfolio.Web.Lib.Data;
using Portfolio.Web.Lib.Queries;

namespace Portfolio.Web.App_Start
{
    public class NinjectConfig
    {
        public static void RegisterServices(IKernel kernel)
        {
            // Data layer bindings
            kernel.Bind<ISessionFactory>().ToConstant(NHibernateConfig.SessionFactory).InSingletonScope();
            kernel.Bind<ISession>().ToMethod(ctx => ctx.Kernel.Get<ISessionFactory>().OpenSession());
            kernel.Bind<IRepository>().To<NHibernateRepository>();
            kernel.Bind<CreateTask>().To<CreateTaskImpl>();
            
            // Service layer bindings
            kernel.Bind<ActionResolver>().To<NinjectActionResolver>();
            kernel.Bind<HttpRequestBase>().ToMethod(ctx => ctx.Kernel.Get<HttpContextBase>().Request);            

            // Web layer and generic service bindings
            kernel.Bind<IClock>().To<SystemClock>();
            kernel.Bind<IUserSettings>().To<HttpUserSettings>();
        }
    }
}