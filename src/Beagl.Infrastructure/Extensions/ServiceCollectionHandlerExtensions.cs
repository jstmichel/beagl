// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Services.Handlers;
using Beagl.Infrastructure.Services.Implementations.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Beagl.Infrastructure.Extensions;

/// <summary>
/// Extension methods for registering handler services.
/// </summary>
public static class ServiceCollectionHandlerExtensions
{
    /// <summary>
    /// Adds handler services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddHandlerServices(this IServiceCollection services)
    {
        services.AddScoped<IUserCreationHandler, UserCreationHandler>();
        services.AddScoped<IUserDeletionHandler, UserDeletionHandler>();
        services.AddScoped<IUserUpdateHandler, UserUpdateHandler>();
        return services;
    }
}
