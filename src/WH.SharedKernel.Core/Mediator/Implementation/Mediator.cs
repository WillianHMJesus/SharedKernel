using System.Threading;
using System.Threading.Tasks;
using WH.SimpleMediator;

namespace WH.SharedKernel.Mediator;

internal sealed class Mediator(SimpleMediator.IMediator mediator) : IMediator
{
    public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
        where TNotification : INotification
    {
        await mediator.Publish(notification, cancellationToken);
    }

    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        return await mediator.Send(request, cancellationToken);
    }
}
