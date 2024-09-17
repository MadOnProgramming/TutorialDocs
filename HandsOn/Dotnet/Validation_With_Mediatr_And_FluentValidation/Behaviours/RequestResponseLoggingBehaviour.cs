using MediatR;

namespace Validation_With_Mediatr_And_FluentValidation.Behaviours
{
    public class RequestResponseLoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<RequestResponseLoggingBehaviour<TRequest, TResponse>> _logger;
        public RequestResponseLoggingBehaviour(ILogger<RequestResponseLoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var correlationId = Guid.NewGuid();

            _logger.LogInformation("Handling Request {Name} ({@Request}) with CorrelationId: {CorrelationId}", typeof(TRequest).Name, request, correlationId);

            var response = await next();

            _logger.LogInformation("Handled Request {Name} ({@Response}) with CorrelationId: {CorrelationId}", typeof(TRequest).Name,response, correlationId);

            return response;
        }
    }
}
