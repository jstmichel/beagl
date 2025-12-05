// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Beagl.WebApp.Resources.Pages.Users;

namespace Beagl.WebApp.Pages.Users.ViewModels;

/// <summary>
/// View model for creating a new user.
/// </summary>
public sealed class CreateUserViewModel
{

    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "UserName_Required")]
    [DataType(DataType.Text)]
    public string UserName { get; set; } = string.Empty;

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
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the roles assigned to the user.
    /// </summary>
    public Collection<string> Roles { get; } = [];

    /// <summary>
    /// Gets or sets the password for the new user.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "Password_Required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the password for the new user.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "ConfirmPassword_Required")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = string.Empty;
}
