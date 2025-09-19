using System.Threading;
using System.Threading.Tasks;

namespace WH.SharedKernel.Mediator;

public class Mediator(SimpleMediator.IMediator mediator) : IMediator
{
    public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
        where TNotification : SimpleMediator.INotification
    {
        await mediator.Publish(notification, cancellationToken);
    }

    public async Task<TResponse> Send<TResponse>(SimpleMediator.IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        return await mediator.Send(request, cancellationToken);
    }
}

