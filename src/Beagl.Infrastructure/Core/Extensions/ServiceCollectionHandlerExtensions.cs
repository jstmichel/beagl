// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.UserManagement.Handlers;
using Beagl.Infrastructure.UserManagement.Interfaces.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Beagl.Infrastructure.Core.Extensions;

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
