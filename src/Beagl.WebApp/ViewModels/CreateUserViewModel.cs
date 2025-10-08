// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.ComponentModel.DataAnnotations;

namespace Beagl.WebApp.ViewModels;

internal sealed class CreateUserViewModel
{

    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    [Required]
    [DataType(DataType.Text)]
    public required string UserName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address.
    /// </summary>
    [Required]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number.
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the roles assigned to the user.
    /// </summary>
    public List<string> Roles { get; set; } = [];

    /// <summary>
    /// Gets or sets the password for the new user.
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; } = string.Empty;
}
