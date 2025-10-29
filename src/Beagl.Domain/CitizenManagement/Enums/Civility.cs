// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.CitizenManagement.Enums;

/// <summary>
/// Represents the civility (title) of a person.
/// </summary>
public enum Civility
{
    /// <summary>
    /// No civility specified.
    /// </summary>
    None = 0,

    /// <summary>
    /// Mister
    /// </summary>
    Mr = 1,

    /// <summary>
    /// Misses
    /// </summary>
    Mrs = 2,

    /// <summary>
    /// Miss
    /// </summary>
    Ms = 3,

    /// <summary>
    /// Mx (gender-neutral)
    /// </summary>
    Mx = 4,

    /// <summary>
    /// Doctor
    /// </summary>
    Dr = 5,

    /// <summary>
    /// Professor
    /// </summary>
    Prof = 6
}
