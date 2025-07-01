using WH.SimpleMediator;

namespace WH.SharedKernel.Mediator;

public interface IEventHandler<TNotification> : INotificationHandler<TNotification>
    where TNotification : INotification
{ }
