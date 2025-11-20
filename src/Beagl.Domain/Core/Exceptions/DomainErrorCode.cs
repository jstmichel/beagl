// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.Core.Exceptions;

/// <summary>
/// Enumeration of domain error codes.
/// </summary>
public enum DomainErrorCode
{
    /// <summary>
    /// Unknown error.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Invalid first name in PersonName value object.
    /// </summary>
    PersonNameInvalidFirstName = 101,

    /// <summary>
    /// Invalid last name in PersonName value object.
    /// </summary>
    PersonNameInvalidLastName = 102,

    /// <summary>
    /// First name too long in PersonName value object.
    /// </summary>
    PersonNameFirstNameTooLong = 104,

    /// <summary>
    /// Last name too long in PersonName value object.
    /// </summary>
    PersonNameLastNameTooLong = 103,
}
