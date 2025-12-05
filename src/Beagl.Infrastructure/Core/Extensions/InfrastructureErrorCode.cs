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

    /// <summary>
    /// Error code indicating that the user is required.
    /// </summary>
    public const string UserRequired = "UserRequired";

    /// <summary>
    /// Error code indicating that the user password is invalid.
    /// </summary>
    public const string UserPasswordIsInvalid = "UserPasswordIsInvalid";

    /// <summary>
    /// Error code indicating that at least one role must be specified for the user.
    /// </summary>
    public const string UserAtLeastOneRoleMustBeSpecified = "UserAtLeastOneRoleMustBeSpecified";

    /// <summary>
    /// Error code indicating that the username is required.
    /// </summary>
    public const string UserNameRequired = "UserNameRequired";

    /// <summary>
    /// Error code indicating that the username already exists.
    /// </summary>
    public const string UserNameAlreadyExists = "UserNameAlreadyExists";

    /// <summary>
    /// Error code indicating that the email is required.
    /// </summary>
    public const string UserEmailRequired = "UserEmailRequired";

    /// <summary>
    /// Error code indicating that the email already exists.
    /// </summary>
    public const string UserEmailAlreadyExists = "UserEmailAlreadyExists";
}
