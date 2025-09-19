using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;
using WH.SharedKernel.Mediator;
using WH.SimpleMediator.Extensions.Microsoft.DependencyInjection;

namespace WH.Extensions.Microsoft.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuthenticationJwt(
        this IServiceCollection services,
        string secretKey)
    {
        JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        services.AddAuthorization();

        return services;
    }

    public static IServiceCollection AddMediator(
        this IServiceCollection services,
        params Assembly[] assemblies)
    {
        if (assemblies.Any())
        {
            throw new ArgumentException("No assemblies found to scan. Supply at least one assembly to scan for handlers.");
        }

        services.AddScoped<IMediator, Mediator>();

        services.AddSimpleMediator(config =>
        {
            config.RegisterServicesFromAssemblies(assemblies);
        });

        return services;
    }

    public static IServiceCollection AddMediator(
        this IServiceCollection services,
        Action<MediatorServiceConfiguration> configuration)
    {
        var serviceConfig = new MediatorServiceConfiguration();
        configuration.Invoke(serviceConfig);

        return services.AddMediator(serviceConfig);
    }

    public static IServiceCollection AddMediator(
       this IServiceCollection services,
       MediatorServiceConfiguration configuration)
    {
        if (!configuration.AssembliesToRegister.Any())
        {
            throw new ArgumentException("No assemblies found to scan. Supply at least one assembly to scan for handlers.");
        }

        services.AddScoped<IMediator, Mediator>();

        services.AddSimpleMediator(config =>
        {
            config.RegisterServicesFromAssemblies(configuration.AssembliesToRegister.ToArray());
            configuration.BehaviorsToRegister.ForEach(x => config.AddPipelineBehavior(x));
            
        });

        return services;
    }

    public static IServiceCollection AddEmailSender(
        this IServiceCollection services,
        ServiceLifetime lifetime)
    {
        services.Add(new ServiceDescriptor(typeof(IEmailSender), typeof(IEmailSender), lifetime));

        return services;
    }
}
