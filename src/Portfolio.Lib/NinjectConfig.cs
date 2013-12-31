using System;
using System.Diagnostics.Contracts;
using System.Web;
using NHibernate;
using Ninject;
using Portfolio.Lib.Commands;
using Portfolio.Lib.Data;
using Portfolio.Lib.Models;
using Portfolio.Lib.Queries;
using Portfolio.Lib.Services;

namespace Portfolio.Lib
{
    public class NinjectConfig
    {
        public static void RegisterServices(IKernel kernel)
        {
            Contract.Requires<ArgumentNullException>(kernel != null);

            // Data layer bindings
            kernel.Bind<ISessionFactory>().ToConstant(NHibernateConfig.SessionFactory).InSingletonScope();
            kernel.Bind<ISession>().ToMethod(ctx => ctx.Kernel.Get<ISessionFactory>().OpenSession());
            kernel.Bind<IRepository>().To<NHibernateRepository>();
            
            // Service layer bindings
            kernel.Bind<HttpRequestBase>().ToMethod(ctx => ctx.Kernel.Get<HttpContextBase>().Request);
            kernel.Bind<IMediator>().ToMethod(ctx => new NinjectMediator(ctx.Kernel));
            kernel.Bind<IPasswordUtility>().To<BCryptPasswordUtility>();
            kernel.Bind<ITagCreationService>().To<TagCreationServiceImpl>();
            kernel.Bind<ITagDeletionService>().To<TagDeletionServiceImpl>();
            kernel.Bind<ITagUpdateService>().To<TagUpdateServiceImpl>();
            kernel.Bind<ITaskCompletionService>().To<TaskCompletionServiceImpl>();
            kernel.Bind<ITaskCreationService>().To<TaskCreationServiceImpl>();
            kernel.Bind<ITaskDeletionService>().To<TaskDeletionServiceImpl>();
            kernel.Bind<ITaskUpdateService>().To<TaskUpdateServiceImpl>();

            // Commands
            kernel.Bind<ICommandHandler<LogonCommand, LogonResult>>().To<LogonCommandHandler>();

            // Queries
            kernel.Bind<IQueryHandler<OpenTasksQuery, TaskCollection>>().To<OpenTasksQueryHandler>();
            kernel.Bind<IQueryHandler<TaskByIdQuery, Task>>().To<TaskByIdQueryHandler>();

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