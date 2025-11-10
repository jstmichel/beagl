// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Collections.ObjectModel;

namespace Beagl.Application.UserManagement.DTOs;

/// <summary>
/// Data transfer object for user data in the domain layer.
/// </summary>
public class UserDto
{
    /// <summary>
    /// Gets or sets the unique identifier for the user.
    /// </summary>
    public string Id { get; set; } = string.Empty;

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
    /// Gets or sets the lockout end date for the user, if any.
    /// </summary>
    public DateTimeOffset? LockoutEnd { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user is soft deleted.
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Gets the roles assigned to the user.
    /// </summary>
    public Collection<string> Roles { get; init; } = [];

    /// <summary>
    /// Gets or sets a value indicating whether the user can be locked out.
    /// </summary>
    public bool LockoutEnabled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether two-factor authentication is enabled for the user.
    /// </summary>
    public bool TwoFactorEnabled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user's email is confirmed.
    /// </summary>
    public bool EmailConfirmed { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user's phone number is confirmed.
    /// </summary>
    public bool PhoneNumberConfirmed { get; set; }
}
