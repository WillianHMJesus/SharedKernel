using System;

namespace WH.SharedKernel;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }

    public abstract void Validate();
}
