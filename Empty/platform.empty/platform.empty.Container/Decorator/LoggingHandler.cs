using MediatR;
using platform.empty.ApiContract.Contract;
using System.Diagnostics;

namespace platform.empty.Container.Decorator
{
    public class LoggingHandler<TRequest, TResponse> : DecoratorBase<TRequest, TResponse>
        where TResponse : ResponseBaseMessage, new() where TRequest : IRequest<TResponse>
    {
        //private readonly IAppLogger _appLogger;

        //public ExceptionHandler(IAppLogger appLogger) 
        //{
        //    _appLogger = appLogger;
        //}


        public override async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var handlerMethodInfo = GetHandlerMethodInfo();

            //_appLogger.MethodEntry(request, handlerMethodInfo);

            //var timer = new Stopwatch();
            //timer.Start();

            var response = await next();

            //timer.Stop();

            //_appLogger.MethodExit(response, handlerMethodInfo, timer.Elapsed.TotalMilliseconds, response.MessageCode);

            return response;
        }
    }
}
