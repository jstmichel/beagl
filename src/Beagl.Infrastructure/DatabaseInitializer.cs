using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Beagl.Domain.Entities;

namespace Beagl.Infrastructure;

/// <summary>
/// Provides methods to initialize the application's database, apply migrations, and seed default roles and users.
/// </summary>
public static class DatabaseInitializer
{
    /// <summary>
    /// Applies pending migrations and seeds default roles and users using configuration values.
    /// </summary>
    /// <param name="serviceProvider">The application's service provider.</param>
    /// <param name="configuration">The configuration containing seed data.</param>
    public static async Task InitializeAsync(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        using IServiceScope scope = serviceProvider.CreateScope();
        ApplicationDbContext db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await db.Database.MigrateAsync();

        UserManager<IdentityUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

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
        string adminEmail = configuration["SeedData:SeedUser:Email"] ?? string.Empty;
        string adminPassword = configuration["SeedData:SeedUser:Password"] ?? string.Empty;
        await CreateUserIfNotExistsAsync(
            userManager,
            adminEmail,
            adminPassword,
            RoleNames.Development);
    }

    private static async Task CreateRoleIfNotExistsAsync(
        RoleManager<IdentityRole> roleManager,
        string roleName)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    private static async Task CreateUserIfNotExistsAsync(
        UserManager<IdentityUser> userManager,
        string email,
        string password,
        string roleName)
    {
        IdentityUser? user = await userManager.FindByEmailAsync(email);
        if (user == null)
        {
            user = new IdentityUser
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
