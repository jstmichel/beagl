// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents the gender of an animal.
/// </summary>
public enum Gender
{
    /// <summary>
    /// Unknown gender.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Male gender.
    /// </summary>
    Male = 1,

    /// <summary>
    /// Female gender.
    /// </summary>
    Female = 2,
}

/// <summary>
/// Helper methods for the <see cref="Gender"/> enum.
/// </summary>
public static class GenderHelper
{
    /// <summary>
    /// Converts an integer to a <see cref="Gender"/> enum value.
    /// </summary>
    public static Gender FromInt(int value)
    {
        if (!Enum.IsDefined(typeof(Gender), value))
            throw new ArgumentException("Invalid gender value.", nameof(value));
        return (Gender)value;
    }
}
