using WH.SharedKernel.ResourceManagers;
using WH.SimpleMediator;

namespace WH.SharedKernel.Mediator;

public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{ }
