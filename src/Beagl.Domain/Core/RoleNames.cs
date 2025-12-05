// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.Core;

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
    /// The employee role, for general staff members.
    /// </summary>
    public const string Employee = "Employee";

    /// <summary>
    /// The development role, for users involved in software or technical development.
    /// </summary>
    public const string Development = "Development";

    /// <summary>
    /// The citizen role, for external users.
    /// </summary>
    public const string Citizen = "Citizen";
}
