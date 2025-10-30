// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Core;
using Beagl.Infrastructure;
using Beagl.WebApp.Constants;
using Microsoft.AspNetCore.Authorization;

namespace Beagl.WebApp.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="WebApplication"/> class to support application startup tasks.
/// </summary>
#pragma warning disable CA1515 // Consider making public types internal
public static class WebApplicationExtensions
#pragma warning restore CA1515 // Consider making public types internal
{
    /// <summary>
    /// Applies any pending database migrations and seeds initial data using the provided configuration.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="configuration">The application configuration containing seed data and other settings.</param>
    public static async Task ExecuteMigrationsAsync(this WebApplication app, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(app);
        ArgumentNullException.ThrowIfNull(configuration);

        await DatabaseInitializer.InitializeAsync(app.Services, configuration).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds authorization policies to the authorization builder.
    /// </summary>
    /// <param name="builder">The authorization builder.</param>
    /// <returns>The updated authorization builder.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="builder"/> is null.</exception>
    public static AuthorizationBuilder AddPolicies(this AuthorizationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        _ = builder
            .AddUserPolicies()
            .AddAnimalPolicies()
            .AddCitizenPolicies();

        return builder;
    }

    /// <summary>
    /// Adds the view user policy to the authorization builder.
    /// </summary>
    /// <param name="builder">The authorization builder.</param>
    /// <returns>The updated authorization builder.</returns>
    private static AuthorizationBuilder AddUserPolicies(this AuthorizationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.AddPolicy(Policies.Users.CanView, policy =>
            policy.RequireRole(
                RoleNames.Administrator,
                RoleNames.Development));

        builder.AddPolicy(Policies.Users.CanEdit, policy =>
            policy.RequireRole(
                RoleNames.Administrator,
                RoleNames.Development));

        builder.AddPolicy(Policies.Users.CanDelete, policy =>
            policy.RequireRole(
                RoleNames.Administrator,
                RoleNames.Development));

        builder.AddPolicy(Policies.Users.CanCreate, policy =>
            policy.RequireRole(
                RoleNames.Administrator,
                RoleNames.Development));

        return builder;
    }

    /// <summary>
    /// Adds the citizen management policies to the authorization builder.
    /// </summary>
    /// <param name="builder">The authorization builder.</param>
    /// <returns>The updated authorization builder.</returns>
    private static AuthorizationBuilder AddCitizenPolicies(this AuthorizationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.AddPolicy(Policies.Citizens.CanView, policy =>
            policy.RequireRole(
                RoleNames.Administrator,
                RoleNames.Development));

        builder.AddPolicy(Policies.Citizens.CanEdit, policy =>
            policy.RequireRole(
                RoleNames.Administrator,
                RoleNames.Development));

        builder.AddPolicy(Policies.Citizens.CanDelete, policy =>
            policy.RequireRole(
                RoleNames.Administrator,
                RoleNames.Development));

        builder.AddPolicy(Policies.Citizens.CanCreate, policy =>
            policy.RequireRole(
                RoleNames.Administrator,
                RoleNames.Development));

        return builder;
    }

    private static AuthorizationBuilder AddAnimalPolicies(this AuthorizationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.AddPolicy(Policies.Animals.CanView, policy =>
            policy.RequireRole(
                RoleNames.Administrator,
                RoleNames.Development));

        builder.AddPolicy(Policies.Animals.CanEdit, policy =>
            policy.RequireRole(
                RoleNames.Administrator,
                RoleNames.Development));

        builder.AddPolicy(Policies.Animals.CanDelete, policy =>
            policy.RequireRole(
                RoleNames.Administrator,
                RoleNames.Development));

        builder.AddPolicy(Policies.Animals.CanCreate, policy =>
            policy.RequireRole(
                RoleNames.Administrator,
                RoleNames.Development));

        return builder;
    }
}
