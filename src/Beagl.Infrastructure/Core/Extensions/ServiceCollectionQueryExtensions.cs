// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.UserManagement.Interfaces;
using Beagl.Infrastructure.UserManagement.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Beagl.Infrastructure.Core.Extensions;

/// <summary>
/// Extension methods for registering query services.
/// </summary>
public static class ServiceCollectionQueryExtensions
{
    /// <summary>
    /// Adds query services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddQueryServices(this IServiceCollection services)
    {
        services.AddScoped<IUserQueryService, UserQueryService>();
        return services;
    }
}
