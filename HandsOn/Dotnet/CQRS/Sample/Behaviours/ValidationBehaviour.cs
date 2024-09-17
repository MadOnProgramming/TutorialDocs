using FluentValidation;
using MediatR;

namespace CQRS.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<ValidationBehaviour<TRequest, TResponse>> _logger;
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviour(ILogger<ValidationBehaviour<TRequest, TResponse>> logger, IEnumerable<IValidator<TRequest>> validators)
        {
            _logger = logger;
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(next);

            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken))).ConfigureAwait(false);
                var failures
                    = validationResults
                        .Where(result => result.Errors.Any())
                        .SelectMany(result => result.Errors)
                        .ToList();
                if (failures.Any())
                {
                    throw new FluentValidation.ValidationException(failures);
                }
            }

            return await next().ConfigureAwait(false);
        }
    }
}
