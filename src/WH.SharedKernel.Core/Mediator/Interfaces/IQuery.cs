using WH.SharedKernel.ResourceManagers;
using WH.SimpleMediator;

namespace WH.SharedKernel.Mediator;

public interface IQuery<TResponse> : IRequest<TResponse> where TResponse : Result { }
