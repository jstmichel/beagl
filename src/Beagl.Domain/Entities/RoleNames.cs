using System;

namespace Beagl.Domain.Entities;

/// <summary>
/// Provides constant role names used throughout the application for authorization and identity management.
/// </summary>
public static class RoleNames
{
    /// <summary>
    /// The administrator role, with full access to all features and settings.
    /// </summary>
    public const string Administrator = "Administrator";

    /// <summary>
    /// The control role, typically for animal control officers.
    /// </summary>
    public const string Control = "Control";

    /// <summary>
    /// The employee role, for general staff members.
    /// </summary>
    public const string Employee = "Employee";

    /// <summary>
    /// The security role, for users responsible for security operations.
    /// </summary>
    public const string Security = "Security";

    /// <summary>
    /// The development role, for users involved in software or technical development.
    /// </summary>
    public const string Development = "Development";

    /// <summary>
    /// The marketing role, for users handling marketing activities.
    /// </summary>
    public const string Marketing = "Marketing";

    /// <summary>
    /// The finance role, for users managing financial operations.
    /// </summary>
    public const string Finance = "Finance";

    /// <summary>
    /// The board member role, for members of the organization's board.
    /// </summary>
    public const string BoardMember = "Board Member";

    /// <summary>
    /// The sales role, for users involved in sales activities.
    /// </summary>
    public const string Sales = "Sales";

    /// <summary>
    /// The citizen role, for external users.
    /// </summary>
    public const string Citizen = "Citizen";
}
