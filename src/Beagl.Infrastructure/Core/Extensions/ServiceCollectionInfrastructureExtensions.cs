// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.Services;
using Beagl.Application.CitizenManagement.Services;
using Beagl.Domain.AnimalManagement.Repositories;
using Beagl.Domain.CitizenManagement.Repositories;
using Beagl.Infrastructure.AnimalManagement.Repositories;
using Beagl.Infrastructure.AnimalManagement.Services;
using Beagl.Infrastructure.CitizenManagement.Repositories;
using Beagl.Infrastructure.CitizenManagement.Services;
using Beagl.Infrastructure.UserManagement.Handlers;
using Beagl.Infrastructure.UserManagement.Interfaces;
using Beagl.Infrastructure.UserManagement.Interfaces.Handlers;
using Beagl.Infrastructure.UserManagement.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Beagl.Infrastructure.Core.Extensions;

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

    /// <summary>
    /// Adds entity mappers to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        return services;
    }

    /// <summary>
    /// Adds domain services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        return services;
    }

    /// <summary>
    /// Adds application services to the service collection.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICatService, CatService>();
        services.AddScoped<IDogService, DogService>();
        services.AddScoped<ICitizenService, CitizenService>();

        return services;
    }

    /// <summary>
    /// Adds repositories to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICatRepository, CatRepository>();
        services.AddScoped<IDogRepository, DogRepository>();
        services.AddScoped<ICitizenRepository, CitizenRepository>();
        return services;
    }

    /// <summary>
    /// Adds handler services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IUserDeletionValidator, UserDeletionValidator>();
        return services;
    }
}
