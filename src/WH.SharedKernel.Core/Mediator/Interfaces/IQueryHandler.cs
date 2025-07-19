using WH.SharedKernel.ResourceManagers;
using WH.SimpleMediator;

namespace WH.SharedKernel.Mediator;

public interface IQueryHandler<TQuery> : IRequestHandler<TQuery, Result>
    where TQuery : IQuery
{ }
