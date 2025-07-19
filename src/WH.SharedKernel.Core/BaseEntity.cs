using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WH.SharedKernel.Core;

namespace WH.SharedKernel;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }

    private readonly List<DomainEvent> _domainEvents = new();

    [NotMapped]
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public abstract void Validate();

    protected void RegisterDomainEvent(DomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    internal void ClearDomainEvents() => _domainEvents.Clear();
}
