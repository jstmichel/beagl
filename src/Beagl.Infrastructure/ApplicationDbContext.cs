// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Beagl.Infrastructure.Entities;

namespace Beagl.Infrastructure;

/// <summary>
/// Represents the Entity Framework database context for the application.
/// </summary>
/// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
{

    // Add your DbSet<T> properties here

}
