// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Beagl.WebApp.Resources.Pages.Users;

namespace Beagl.WebApp.Pages.Users.ViewModels;

/// <summary>
/// ViewModel for editing user details in the UI.
/// Contains only the fields required for user editing.
/// </summary>
public sealed class EditUserViewModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the user.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Gets the username.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "UserName_Required")]
    [DataType(DataType.Text)]
    public string? UserName { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "Email_Required")]
    [EmailAddress(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "EmailFormat_Invalid")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "Phone_Required")]
    [Phone(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "PhoneFormat_Invalid")]
    public string? PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the roles assigned to the user.
    /// </summary>
    public Collection<string> Roles { get; init; } = [];
}
