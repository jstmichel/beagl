// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Beagl.Domain.Core;
using Beagl.Infrastructure.UserManagement.Entities;
using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.AnimalManagement.Enums;

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

        ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await AddCatColorsIfNoneExistsAsync(dbContext);
        await AddDogColorsIfNoneExistsAsync(dbContext);

        await AddCatBreedsIfNoneExistsAsync(dbContext);
        await AddDogBreedsIfNoneExistsAsync(dbContext);
    }

    private static async Task AddDogBreedsIfNoneExistsAsync(
        ApplicationDbContext dbContext)
    {
        if (!await dbContext.Breeds.AnyAsync(b => b.SpeciesType == SpeciesType.Dog))
        {
            Breed[] breeds =
            [
                new Breed("Labrador Retriever", SpeciesType.Dog),
                new Breed("Berger Allemand", SpeciesType.Dog),
                new Breed("Golden Retriever", SpeciesType.Dog),
                new Breed("Bulldog Français", SpeciesType.Dog),
                new Breed("Beagle", SpeciesType.Dog),
                new Breed("Caniche", SpeciesType.Dog),
                new Breed("Rottweiler", SpeciesType.Dog),
                new Breed("Yorkshire Terrier", SpeciesType.Dog)
            ];

            dbContext.Breeds.AddRange(breeds);
            await dbContext.SaveChangesAsync();
        }
    }

    private static async Task AddCatBreedsIfNoneExistsAsync(
        ApplicationDbContext dbContext)
    {
        if (!await dbContext.Breeds.AnyAsync(b => b.SpeciesType == SpeciesType.Cat))
        {
            Breed[] breeds =
            [
                new Breed("Siamois", SpeciesType.Cat),
                new Breed("Maine Coon", SpeciesType.Cat),
                new Breed("Chartreux", SpeciesType.Cat),
                new Breed("Persan", SpeciesType.Cat),
                new Breed("Sacré de Birmanie", SpeciesType.Cat),
                new Breed("British Shorthair", SpeciesType.Cat),
                new Breed("Bengal", SpeciesType.Cat),
                new Breed("Sphynx", SpeciesType.Cat)
            ];

            dbContext.Breeds.AddRange(breeds);
            await dbContext.SaveChangesAsync();
        }
    }

    private static async Task AddDogColorsIfNoneExistsAsync(
        ApplicationDbContext dbContext)
    {
        if (!await dbContext.Colors.AnyAsync(c => c.SpeciesType == SpeciesType.Dog))
        {
            Color[] colors =
            [
                new Color("Noir", SpeciesType.Dog),
                new Color("Blanc", SpeciesType.Dog),
                new Color("Marron", SpeciesType.Dog),
                new Color("Doré", SpeciesType.Dog),
                new Color("Gris", SpeciesType.Dog),
                new Color("Tacheté", SpeciesType.Dog)
            ];

            dbContext.Colors.AddRange(colors);
            await dbContext.SaveChangesAsync();
        }
    }

    private static async Task AddCatColorsIfNoneExistsAsync(
        ApplicationDbContext dbContext)
    {
        if (!await dbContext.Colors.AnyAsync(c => c.SpeciesType == SpeciesType.Cat))
        {
            Color[] colors =
            [
                new Color("Noir", SpeciesType.Cat),
                new Color("Blanc", SpeciesType.Cat),
                new Color("Gris", SpeciesType.Cat),
                new Color("Rouge", SpeciesType.Cat),
                new Color("Tigré", SpeciesType.Cat),
                new Color("Calico", SpeciesType.Cat)
            ];

            dbContext.Colors.AddRange(colors);
            await dbContext.SaveChangesAsync();
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
