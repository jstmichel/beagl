// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Text.RegularExpressions;

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents a Medal awarded to an animal, encapsulating business rules and validation.
/// </summary>
public sealed partial class Medal : IEquatable<Medal>
{
    private const int _maxLength = 30;
    private static readonly Regex _allowedPattern = FormatValidationRegex();

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
        ValidateInvariant(value);
        Value = value;
    }

    /// <summary>
    /// Returns the string representation of the medal.
    /// </summary>
    public override string ToString() => Value;

    /// <summary>
    /// Determines whether the specified object is equal to the current medal.
    /// </summary>
    public override bool Equals(object? obj) => Equals(obj as Medal);

    /// <summary>
    /// Determines whether the specified medal is equal to the current medal.
    /// </summary>
    public bool Equals(Medal? other) => other is not null && Value == other.Value;

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

    [GeneratedRegex("^[A-Za-z0-9\\- ]+$", RegexOptions.Compiled, 20)]
    private static partial Regex FormatValidationRegex();

    /// <summary>
    /// Creates a Medal value object from the given string.
    /// </summary>
    /// <param name="value">The medal value.</param>
    public static Medal? From(string? value) =>
        string.IsNullOrWhiteSpace(value) ? null : new Medal(value);

    /// <summary>
    /// Validates the medal value against business rules.
    /// </summary>
    public static (bool isValid, string? error) Validate(string value)
    {
        if (!ValidateNotEmpty(value).isValid) return (false, ValidateNotEmpty(value).error);
        if (!ValidateMaxLength(value).isValid) return (false, ValidateMaxLength(value).error);
        if (!ValidatePattern(value).isValid) return (false, ValidatePattern(value).error);
        return (true, null);
    }

    private static (bool isValid, string? error) ValidateNotEmpty(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return (false, "Medal cannot be empty.");
        }
        return (true, null);
    }

    private static (bool isValid, string? error) ValidateMaxLength(string value)
    {
        if (value.Length > _maxLength)
        {
            return (false, $"Medal cannot exceed {_maxLength} characters.");
        }
        return (true, null);
    }

    private static (bool isValid, string? error) ValidatePattern(string value)
    {
        if (!_allowedPattern.IsMatch(value))
        {
            return (false, "Medal contains invalid characters.");
        }
        return (true, null);
    }

    private static void ValidateInvariant(string value)
    {
        (bool isValid, string? error) = Validate(value);
        if (!isValid)
        {
            throw new ArgumentException(error, nameof(value));
        }
    }
}
