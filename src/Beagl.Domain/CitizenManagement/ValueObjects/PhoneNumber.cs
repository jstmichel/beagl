// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Text.RegularExpressions;

namespace Beagl.Domain.CitizenManagement.ValueObjects;

/// <summary>
/// Value object representing a phone number.
/// </summary>
public sealed class PhoneNumber : IEquatable<PhoneNumber>
{
    /// <summary>
    /// Gets the phone number as a string.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PhoneNumber"/> class.
    /// </summary>
    /// <param name="value">The phone number string.</param>
    /// <exception cref="ArgumentException">Thrown if the phone number is invalid.</exception>
    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Phone number cannot be null or empty.", nameof(value));
        }

        if (!Regex.IsMatch(value, @"^[\d\s\-\(\)\+xXextEXT\./]+$"))
        {
            throw new ArgumentException("Phone number contains invalid characters.", nameof(value));
        }

        string digits = Regex.Replace(value, "[^0-9]", "");
        if (string.IsNullOrWhiteSpace(digits))
        {
            throw new ArgumentException("Phone number must contain at least one digit.", nameof(value));
        }

        Value = digits;
    }

    /// <inheritdoc/>
    public bool Equals(PhoneNumber? other) => other is not null && Value == other.Value;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as PhoneNumber);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <summary>
    /// Equality operator for PhoneNumber.
    /// </summary>
    public static bool operator ==(PhoneNumber? left, PhoneNumber? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Inequality operator for PhoneNumber.
    /// </summary>
    public static bool operator !=(PhoneNumber? left, PhoneNumber? right)
    {
        return !Equals(left, right);
    }

    /// <summary>
    /// Returns the formatted phone number for display.
    /// </summary>
    public string? ToDisplayString()
    {
        if (string.IsNullOrWhiteSpace(Value))
        {
            return null;
        }

        if (Value.Length == 11 && Value.StartsWith('1'))
        {
            return $"+1 ({Value.Substring(1, 3)}) {Value.Substring(4, 3)}-{Value.Substring(7, 4)}";
        }

        if (Value.Length == 10)
        {
            return $"({Value[..3]}) {Value[3..6]}-{Value[6..]}";
        }

        return Value;
    }

    /// <summary>
    /// Creates a PhoneNumber instance from a string, returning null if the string is null or whitespace.
    /// </summary>
    /// <param name="value">The phone number string.</param>
    /// <returns>A PhoneNumber instance or null.</returns>
    public static PhoneNumber? From(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return new PhoneNumber(value);
    }
}
