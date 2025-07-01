using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WH.SharedKernel.Mediator;
using WH.SimpleMediator.Extensions.Microsoft.DependencyInjection;
using MediatorImplementation = WH.SharedKernel.Mediator.Mediator;

namespace WH.SharedKernel.Extensions.Microsoft.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddSingleton<IMediator, MediatorImplementation>();
        services.AddSimpleMediator(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(assemblies);
            cfg.AddPipelineBehavior(typeof(ValidationBehavior<,>));
        });

        return services;
    }
}
