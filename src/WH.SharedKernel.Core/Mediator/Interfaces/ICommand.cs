using WH.SharedKernel.ResourceManagers;
using WH.SimpleMediator;

namespace WH.SharedKernel.Mediator;

public interface ICommand<TResponse> : IRequest<TResponse> where TResponse : Result { }
