using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WH.SharedKernel.ResourceManagers;
using WH.SimpleMediator;

namespace WH.SharedKernel.Mediator;

public sealed class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!validators.Any())
        {
            return await next();
        }

        ValidationResult[] validationResult = await Task.WhenAll(validators.Select(async x => await x.ValidateAsync(request, cancellationToken)));

        string[] errorMessages = validationResult
            .SelectMany(validationResult => validationResult.Errors)
            .Where(validateFailure => validateFailure is not null)
            .Select(failure => failure.ErrorMessage)
        .Distinct()
        .ToArray();

        if (errorMessages.Any())
        {
            return (TResponse)Result.CreateResponseWithErrors(errorMessages.Select(errorMessage => new Error("ApplicationError", errorMessage)));
        }

        return await next();
    }
}
