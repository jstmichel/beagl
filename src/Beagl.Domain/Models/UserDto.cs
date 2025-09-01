// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Collections.ObjectModel;

namespace Beagl.Domain.Models;

/// <summary>
/// Data transfer object for user data in the domain layer.
/// </summary>
public class UserDto
{
    /// <summary>
    /// Gets or sets the unique identifier for the user.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number.
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user is soft deleted.
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Gets the roles assigned to the user.
    /// </summary>
    public ReadOnlyCollection<string> Roles { get; init; } = new ReadOnlyCollection<string>([]);
}
