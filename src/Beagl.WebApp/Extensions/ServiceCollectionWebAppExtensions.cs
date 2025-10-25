// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.WebApp.Services;

namespace Beagl.WebApp.Extensions;

/// <summary>
/// Extension methods for registering query services.
/// </summary>
public static class ServiceCollectionWebAppExtensions
{
    /// <summary>
    /// Adds query services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddWebAppServices(this IServiceCollection services)
    {
        services.AddScoped<IStaticDataLocalizerService, StaticDataLocalizerService>();

        return services;
    }
}
