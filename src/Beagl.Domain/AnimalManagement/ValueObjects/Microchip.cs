// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents a microchip identifier for an animal.
/// </summary>
public sealed class Microchip : IEquatable<Microchip>
{
    /// <summary>
    /// Gets the microchip value.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Microchip"/> class.
    /// </summary>
    /// <param name="value">The microchip value.</param>
    /// <exception cref="ArgumentNullException">Thrown when value is null or empty.</exception>
    public Microchip(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value, nameof(value));
        Value = value;
    }

    /// <inheritdoc/>
    public bool Equals(Microchip? other) => other is not null && Value == other.Value;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as Microchip);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <summary>
    /// Equality operator for Microchip value objects.
    /// </summary>
    /// <param name="left">The left Microchip value.</param>
    /// <param name="right">The right Microchip value.</param>
    /// <returns>True if both Microchip values are equal; otherwise, false.</returns>
    public static bool operator ==(Microchip? left, Microchip? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Inequality operator for Microchip value objects.
    /// </summary>
    /// <param name="left">The left Microchip value.</param>
    /// <param name="right">The right Microchip value.</param>
    /// <returns>True if both Microchip values are not equal; otherwise, false.</returns>
    public static bool operator !=(Microchip? left, Microchip? right)
    {
        return !Equals(left, right);
    }

    /// <summary>
    /// Creates a Microchip value object from the given string.
    /// </summary>
    public static Microchip? From(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return new Microchip(value);
    }
}
