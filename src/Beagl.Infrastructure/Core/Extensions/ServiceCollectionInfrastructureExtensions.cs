// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.AnimalManagement.Services;
using Beagl.Infrastructure.CitizenManagement.Services;
using Beagl.Infrastructure.UserManagement.Handlers;
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
    /// Adds application services to the service collection.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAnimalService, AnimalService>();
        services.AddScoped<IAnimalQueryService, AnimalQueryService>();

        services.AddScoped<ICitizenService, CitizenService>();
        services.AddScoped<ICitizenQueryService, CitizenQueryService>();

        services.AddScoped<IUserQueryService, UserQueryService>();
        services.AddScoped<IBreedQueryService, BreedQueryService>();
        services.AddScoped<IColorQueryService, ColorQueryService>();

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
        services.AddScoped<IUserCreationValidator, UserCreationValidator>();
        services.AddScoped<IUserUpdateValidator, UserUpdateValidator>();
        return services;
    }
}
