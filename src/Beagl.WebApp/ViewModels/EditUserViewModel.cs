// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.WebApp.ViewModels;

/// <summary>
/// ViewModel for editing user details in the UI.
/// Contains only the fields required for user editing.
/// </summary>
internal sealed class EditUserViewModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the user.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Gets the username.
    /// </summary>
    public string? UserName { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address.
    /// </summary>
    public string? Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number.
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the roles assigned to the user.
    /// </summary>
    public List<string> Roles { get; set; } = [];
}
