// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Infrastructure.Core.Extensions;

/// <summary>
/// Defines error codes for infrastructure-related errors.
/// </summary>
public static class InfrastructureErrorCode
{
    /// <summary>
    /// Generic unknown error code.
    /// </summary>
    public const string UnknownError = "UnknownError";

    /// <summary>
    /// Error code indicating that the user ID is required.
    /// </summary>
    public const string UserIdRequired = "UserIdRequired";

    /// <summary>
    /// Error code indicating that the user was not found.
    /// </summary>
    public const string UserNotFound = "UserNotFound";

    /// <summary>
    /// Error code indicating that the last user cannot be deleted.
    /// </summary>
    public const string UserCannotDeleteLastUser = "UserCannotDeleteLastUser";
}
