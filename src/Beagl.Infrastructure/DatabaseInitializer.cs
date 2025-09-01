// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Beagl.Domain.Entities;
using Beagl.Infrastructure.Entities;

namespace Beagl.Infrastructure;

/// <summary>
/// Provides methods to initialize the application's database, apply migrations, and seed default roles and users.
/// </summary>
public static class DatabaseInitializer
{
    /// <summary>
    /// Applies pending migrations (if <paramref name="migrate"/> is true) and seeds default roles and users using configuration values.
    /// </summary>
    /// <param name="serviceProvider">The application's service provider.</param>
    /// <param name="configuration">The configuration containing seed data.</param>
    /// <param name="migrate">If true, applies pending migrations before seeding data.</param>
    public static async Task InitializeAsync(IServiceProvider serviceProvider, IConfiguration configuration, bool migrate = true)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        using IServiceScope scope = serviceProvider.CreateScope();
        if (migrate)
        {
            ApplicationDbContext db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await db.Database.MigrateAsync();
        }

        UserManager<ApplicationUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        RoleManager<ApplicationRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

        // Create default roles
        await CreateRoleIfNotExistsAsync(roleManager, RoleNames.Administrator);
        await CreateRoleIfNotExistsAsync(roleManager, RoleNames.Control);
        await CreateRoleIfNotExistsAsync(roleManager, RoleNames.Employee);
        await CreateRoleIfNotExistsAsync(roleManager, RoleNames.Security);
        await CreateRoleIfNotExistsAsync(roleManager, RoleNames.Development);
        await CreateRoleIfNotExistsAsync(roleManager, RoleNames.Marketing);
        await CreateRoleIfNotExistsAsync(roleManager, RoleNames.Finance);
        await CreateRoleIfNotExistsAsync(roleManager, RoleNames.BoardMember);
        await CreateRoleIfNotExistsAsync(roleManager, RoleNames.Sales);
        await CreateRoleIfNotExistsAsync(roleManager, RoleNames.Citizen);

        // Create default user
        string? adminEmail = configuration["SeedData:SeedUser:Email"];
        string? adminPassword = configuration["SeedData:SeedUser:Password"];
        if (!string.IsNullOrWhiteSpace(adminEmail) && !string.IsNullOrWhiteSpace(adminPassword))
        {
            await CreateUserIfNotExistsAsync(
                userManager,
                adminEmail,
                adminPassword,
                RoleNames.Development);
        }
    }

    private static async Task CreateRoleIfNotExistsAsync(
        RoleManager<ApplicationRole> roleManager,
        string roleName)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new ApplicationRole { Name = roleName });
        }
    }

    private static async Task CreateUserIfNotExistsAsync(
        UserManager<ApplicationUser> userManager,
        string email,
        string password,
        string roleName)
    {
        ApplicationUser? user = await userManager.FindByEmailAsync(email);
        if (user == null)
        {
            user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            IdentityResult result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, roleName);
            }
        }
    }
}
