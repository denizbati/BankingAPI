using MediatR;
using Newtonsoft.Json;
using platform.empty.ApiContract.Contract;

namespace platform.empty.Container.Decorator
{
    public class ExceptionHandler<TRequest, TResponse> : DecoratorBase<TRequest, TResponse>
        where TResponse : ResponseBaseMessage, new() where TRequest : IRequest<TResponse>
    {
        //private readonly IAppLogger _appLogger;

        //public ExceptionHandler(IAppLogger appLogger) 
        //{
        //    _appLogger = appLogger;
        //}


        public override async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response;
            var handlerMethodInfo = GetHandlerMethodInfo();
            try
            {
                response = await next();
            }
            catch (Exception exception)
            {
                response = new TResponse
                {
                    Message = "Message",
                    UserMessage = "User Message",
                    MessageCode = "Message Code"
                };

                //_appLogger.Exeption(exception, handlerMethodInfo);

                //switch (exception)
                //{
                //    case BusinessRuleException businessRuleException:
                //        response = new TResponse
                //        {
                //            UserMessage = businessRuleException.UserMessage,
                //            MessageCode = businessRuleException.MessageCode,
                //            Message = businessRuleException.Message,
                //        };
                //        break;
                //    //http timeout
                //    case TaskCanceledException:
                //    case AggregateException:
                //        response = new TResponse
                //        {
                //            UserMessage = ApplicationMessage.TimeoutOccurred.UserMessage(),
                //            Message = ApplicationMessage.TimeoutOccurred.Message(),
                //            MessageCode = ApplicationMessage.TimeoutOccurred
                //        };
                //        break;
                //    //unexpected http response received
                //    case HttpRequestException:
                //    case JsonReaderException:
                //        response = new TResponse
                //        {
                //            UserMessage = ApplicationMessage.UnExpectedHttpResponseReceived.UserMessage(),
                //            Message = ApplicationMessage.UnExpectedHttpResponseReceived.Message(),
                //            MessageCode = ApplicationMessage.UnExpectedHttpResponseReceived
                //        };
                //        break;
                //    default:
                //        response = new TResponse
                //        {
                //            UserMessage = ApplicationMessage.UnhandledError.UserMessage(),
                //            Message = ApplicationMessage.UnhandledError.Message(),
                //            MessageCode = ApplicationMessage.UnhandledError
                //        };
                //        break;
                //}
            }
            return response;
        }
    }
}
