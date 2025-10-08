// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Services;
using Beagl.Infrastructure.Services.Implementations;
using Beagl.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Beagl.Infrastructure.Extensions;

/// <summary>
/// Extension methods for registering infrastructure services.
/// </summary>
public static class ServiceCollectionInfrastructureExtensions
{
    /// <summary>
    /// Adds infrastructure services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();
        return services;
    }
}
