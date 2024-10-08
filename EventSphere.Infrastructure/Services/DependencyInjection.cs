using EventSphere.Application.Abstractions;
using EventSphere.Infrastructure.Services.Auth;
using EventSphere.Infrastructure.Services.TokenProvider;
using Microsoft.Extensions.DependencyInjection;

namespace EventSphere.Infrastructure.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenProviderService, TokenProviderService>();

        return services;
    }
}
