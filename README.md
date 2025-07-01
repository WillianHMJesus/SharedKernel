# WH.SharedKernel

Shared Kernel implementation in .NET

Project created for shared kernel, such as the items below:

General Abstractions

- `AssertionConcern`
- `BaseEntity`
- `DomainException`
- `IAggregateRoot`
- `IRepository`
- `ValueObject`

Mediator Abstractions

- `ICommand`
- `ICommandHandler`
- `IEvent`
- `IEventHandler`
- `IMediator`
- `IQuery`
- `IQueryHandler`

ResourceManagers

- `Error`
- `Result`

### Installing WH.SharedKernel

You should install [WH.SharedKernel with NuGet](https://www.nuget.org/packages/WH.SharedKernel):

    Install-Package WH.SharedKernel

Or via the .NET Core command line interface:

    dotnet add package WH.SharedKernel
