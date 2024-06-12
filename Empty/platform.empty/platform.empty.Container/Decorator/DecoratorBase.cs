using Autofac;
using MediatR;
using platform.empty.ApiContract.Contract;
using System.Reflection;

namespace platform.empty.Container.Decorator
{
    public abstract class DecoratorBase<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : ResponseBaseMessage where TRequest : IRequest<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken);

        protected MethodBase GetHandlerMethodInfo() 
        { 
            var handler = Bootstrapper.Container.Resolve<IRequestHandler<TRequest, TResponse>>();
            return handler?.GetType().GetMethod("Handle");
        }
    }
}
