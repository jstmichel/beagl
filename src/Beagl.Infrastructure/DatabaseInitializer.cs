// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Beagl.Domain.Core;
using Beagl.Infrastructure.UserManagement.Entities;
using Beagl.Infrastructure.AnimalManagement.Models;
using Beagl.Domain.AnimalManagement.ValueObjects;

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
            BreedModel[] breeds =
            [
                new BreedModel { Id = Guid.NewGuid(), Name = "Labrador Retriever", SpeciesType = SpeciesType.Dog },
                new BreedModel { Id = Guid.NewGuid(), Name = "Berger Allemand", SpeciesType = SpeciesType.Dog },
                new BreedModel { Id = Guid.NewGuid(), Name = "Golden Retriever", SpeciesType = SpeciesType.Dog },
                new BreedModel { Id = Guid.NewGuid(), Name = "Bulldog Français", SpeciesType = SpeciesType.Dog },
                new BreedModel { Id = Guid.NewGuid(), Name = "Beagle", SpeciesType = SpeciesType.Dog },
                new BreedModel { Id = Guid.NewGuid(), Name = "Caniche", SpeciesType = SpeciesType.Dog },
                new BreedModel { Id = Guid.NewGuid(), Name = "Rottweiler", SpeciesType = SpeciesType.Dog },
                new BreedModel { Id = Guid.NewGuid(), Name = "Yorkshire Terrier", SpeciesType = SpeciesType.Dog }
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
            BreedModel[] breeds =
            [
                new BreedModel { Id = Guid.NewGuid(), Name = "Siamois", SpeciesType = SpeciesType.Cat },
                new BreedModel { Id = Guid.NewGuid(), Name = "Maine Coon", SpeciesType = SpeciesType.Cat },
                new BreedModel { Id = Guid.NewGuid(), Name = "Chartreux", SpeciesType = SpeciesType.Cat },
                new BreedModel { Id = Guid.NewGuid(), Name = "Persan", SpeciesType = SpeciesType.Cat },
                new BreedModel { Id = Guid.NewGuid(), Name = "Sacré de Birmanie", SpeciesType = SpeciesType.Cat },
                new BreedModel { Id = Guid.NewGuid(), Name = "British Shorthair", SpeciesType = SpeciesType.Cat },
                new BreedModel { Id = Guid.NewGuid(), Name = "Bengal", SpeciesType = SpeciesType.Cat },
                new BreedModel { Id = Guid.NewGuid(), Name = "Sphynx", SpeciesType = SpeciesType.Cat }
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
            ColorModel[] colors =
            [
                new ColorModel { Id = Guid.NewGuid(), Name = "Noir", SpeciesType = SpeciesType.Dog },
                new ColorModel { Id = Guid.NewGuid(), Name = "Blanc", SpeciesType = SpeciesType.Dog },
                new ColorModel { Id = Guid.NewGuid(), Name = "Marron", SpeciesType = SpeciesType.Dog },
                new ColorModel { Id = Guid.NewGuid(), Name = "Doré", SpeciesType = SpeciesType.Dog },
                new ColorModel { Id = Guid.NewGuid(), Name = "Gris", SpeciesType = SpeciesType.Dog },
                new ColorModel { Id = Guid.NewGuid(), Name = "Tacheté", SpeciesType = SpeciesType.Dog }
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
            ColorModel[] colors =
            [
                new ColorModel { Id = Guid.NewGuid(), Name = "Noir", SpeciesType = SpeciesType.Cat },
                new ColorModel { Id = Guid.NewGuid(), Name = "Blanc", SpeciesType = SpeciesType.Cat },
                new ColorModel { Id = Guid.NewGuid(), Name = "Gris", SpeciesType = SpeciesType.Cat },
                new ColorModel { Id = Guid.NewGuid(), Name = "Rouge", SpeciesType = SpeciesType.Cat },
                new ColorModel { Id = Guid.NewGuid(), Name = "Tigré", SpeciesType = SpeciesType.Cat },
                new ColorModel { Id = Guid.NewGuid(), Name = "Calico", SpeciesType = SpeciesType.Cat }
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
