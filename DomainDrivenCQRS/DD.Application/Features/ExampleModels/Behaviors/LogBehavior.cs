using MediatR;
using Microsoft.Extensions.Logging;

namespace DD.Application.Features.ExampleModels.Behaviors
{
    public class LogBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LogBehavior<TRequest, TResponse>> _logger;
        public LogBehavior(ILogger<LogBehavior<TRequest, TResponse>> logger)
            => _logger = logger;        

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");
            var response = await next();

            _logger.LogInformation($"Handled {typeof(TResponse).Name}");

            return response;
        }
    }
}
