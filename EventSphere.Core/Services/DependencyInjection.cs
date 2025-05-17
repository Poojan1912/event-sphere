using EventSphere.Core.Abstractions;
using EventSphere.Core.Services.Event.CreateEvent;
using Microsoft.Extensions.DependencyInjection;

namespace EventSphere.Core.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddEventSphereCoreServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateEventService, CreateEventService>();
        return services;
    }
}
