using System;
using WH.SimpleMediator;

namespace WH.SharedKernel.Core;

public abstract class DomainEvent : INotification
{
    public Guid CorrelationId { get; protected set; } = Guid.NewGuid();
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
