// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents the gender of an animal.
/// </summary>
public sealed class Gender
{
    /// <summary>
    /// Predefined Male gender instances.
    /// </summary>
    public static readonly Gender Male = new("Male");

    /// <summary>
    /// Predefined Female gender instances.
    /// </summary>
    public static readonly Gender Female = new("Female");

    /// <summary>
    /// Predefined Unknown gender instances.
    /// </summary>
    public static readonly Gender Unknown = new("Unknown");

    /// <summary>
    /// Gets the gender value.
    /// </summary>
    public string Value { get; }

    private Gender(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Creates a <see cref="Gender"/> instance from a string value.
    /// </summary>
    public static Gender FromString(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value);
        return value.ToUpperInvariant() switch
        {
            "male" => Male,
            "female" => Female,
            _ => Unknown
        };
    }

    /// <inheritdoc/>
    public override string ToString() => Value;

    /// <inheritdoc/>
    public override bool Equals(object? obj) =>
        obj is Gender g && g.Value == Value;

    /// <inheritdoc/>
    public override int GetHashCode() =>
        Value.GetHashCode(StringComparison.CurrentCulture);
}
