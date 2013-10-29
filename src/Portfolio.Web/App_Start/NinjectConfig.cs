using System.Web;
using NHibernate;
using Ninject;
using Portfolio.Common;
using Portfolio.Data;
using Portfolio.Data.Queries;
using Portfolio.Web.Lib;

namespace Portfolio.Web
{
    public class NinjectConfig
    {
        public static void RegisterServices(IKernel kernel)
        {
            // Data layer bindings
            kernel.Bind<ISessionFactory>().ToConstant(NHibernateConfig.SessionFactory).InSingletonScope();
            kernel.Bind<ISession>().ToMethod(ctx => ctx.Kernel.Get<ISessionFactory>().OpenSession());            
            kernel.Bind<CreateTask>().To<CreateTaskImpl>();
            kernel.Bind<FetchAllCategories>().To<FetchAllCategoriesImpl>();
            kernel.Bind<FetchTaskById>().To<FetchTaskByIdImpl>();
            
            // Command bindings.            
            kernel.Bind<IQueryStore>().To<NinjectQueryStore>();

            // Service layer bindings
            kernel.Bind<ActionResolver>().To<NinjectActionResolver>();
            kernel.Bind<HttpRequestBase>().ToMethod(ctx => ctx.Kernel.Get<HttpContextBase>().Request);            

            // Web layer and generic service bindings
            kernel.Bind<IClock>().To<SystemClock>();
            kernel.Bind<IUserSettings>().To<HttpUserSettings>();
        }
    }
}