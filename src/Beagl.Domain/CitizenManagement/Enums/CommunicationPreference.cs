// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.CitizenManagement.Enums;

/// <summary>
/// Represents the communication preference of a citizen.
/// </summary>
public enum CommunicationPreference
{
    /// <summary>
    /// No communication preference specified.
    /// </summary>
    None = 0,

    /// <summary>
    /// Prefer communication via phone.
    /// </summary>
    Phone = 1,

    /// <summary>
    /// Prefer communication via cell phone.
    /// </summary>
    CellPhone = 2,

    /// <summary>
    /// Prefer communication via email.
    /// </summary>
    Email = 3
}
