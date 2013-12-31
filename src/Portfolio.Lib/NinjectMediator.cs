using System;
using System.Diagnostics.Contracts;
using System.Reflection;
using Ninject;
using Portfolio.Lib.Commands;
using Portfolio.Lib.Queries;

namespace Portfolio.Lib
{
    public class NinjectMediator : IMediator
    {
        readonly IKernel kernel;

        public NinjectMediator(IKernel kernel)
        {
            Contract.Requires<ArgumentNullException>(kernel != null);
            this.kernel = kernel;
        }

        public TResult Request<TResult>(IQuery<TResult> query)
        {
            var handler = GetHandlerMethod(typeof(IQueryHandler<,>), query.GetType(), typeof(TResult));
            var instance = kernel.Get(handler.GenericType);
            var result = handler.Method.Invoke(instance, new object[] { query });
            return (TResult)result;
        }

        public TResult Send<TResult>(ICommand<TResult> command)
        {
            var handler = GetHandlerMethod(typeof(ICommandHandler<,>), command.GetType(), typeof(TResult));
            var instance = kernel.Get(handler.GenericType);            
            var result = handler.Method.Invoke(instance, new object[] { command });
            return (TResult)result;
        }

        private static Handler GetHandlerMethod(Type handlerType, Type paramType, Type resultType, string methodName = "Handle")
        {
            var genericHandlerType = handlerType.MakeGenericType(paramType, resultType);
            var method = genericHandlerType.GetMethod(methodName);
            return new Handler
            {
                GenericType = genericHandlerType,
                Method = method
            };
        }

        class Handler
        {
            public Type GenericType { get; set; }
            public MethodInfo Method { get; set; }
        }
    }
}
