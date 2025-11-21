// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.Core.Exceptions;

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents a Medal awarded to an animal, encapsulating business rules and validation.
/// </summary>
public sealed partial class Medal : IEquatable<Medal>
{
    /// <summary>
    /// Gets the value of the medal.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Medal"/> class.
    /// </summary>
    /// <param name="value">The medal value.</param>
    /// <exception cref="ArgumentException">Thrown when the value does not meet business rules.</exception>
    public Medal(string value)
    {
        ValidateMedalValueIsNotEmpty(value);

        Value = value;
    }

    /// <summary>
    /// Determines whether the specified medal is equal to the current medal.
    /// </summary>
    public bool Equals(Medal? other) => other is not null && Value == other.Value;

    /// <summary>
    /// Determines whether the specified object is equal to the current medal.
    /// </summary>
    public override bool Equals(object? obj) => Equals(obj as Medal);

    /// <summary>
    /// Returns the hash code for the medal.
    /// </summary>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.InvariantCulture);

    /// <summary>
    /// Equality operator for medals.
    /// </summary>
    public static bool operator ==(Medal? left, Medal? right) => Equals(left, right);

    /// <summary>
    /// Inequality operator for medals.
    /// </summary>
    public static bool operator !=(Medal? left, Medal? right) => !Equals(left, right);

    /// <summary>
    /// Creates a Medal value object from the given string.
    /// </summary>
    /// <param name="value">The medal value.</param>
    public static Medal? From(string? value) =>
        string.IsNullOrWhiteSpace(value) ? null : new Medal(value);

    private static void ValidateMedalValueIsNotEmpty(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException(DomainErrorCode.MedalValueCannotBeNullOrEmpty, "Medal value cannot be null or empty.");
        }
    }
}
