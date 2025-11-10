// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Beagl.Application.UserManagement.ViewModels;

/// <summary>
/// View model for creating a new user.
/// </summary>
public sealed class CreateUserViewModel
{

    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    [Required]
    [DataType(DataType.Text)]
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address.
    /// </summary>
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number.
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the roles assigned to the user.
    /// </summary>
    public Collection<string> Roles { get; } = [];

    /// <summary>
    /// Gets or sets the password for the new user.
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the password for the new user.
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = string.Empty;
}
