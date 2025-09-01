// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Infrastructure.Entities;

/// <summary>
/// Represents an application user, extending ASP.NET Core IdentityUser.
/// </summary>
public class ApplicationUser : Microsoft.AspNetCore.Identity.IdentityUser
{
    /// <summary>
    /// Gets or sets a value indicating whether the user is marked as deleted.
    /// </summary>
    public bool IsDeleted { get; set; }
}
