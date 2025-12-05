// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Text.RegularExpressions;
using Beagl.Domain.Core.Exceptions;

namespace Beagl.Domain.CitizenManagement.ValueObjects;

/// <summary>
/// Value object representing a phone number.
/// </summary>
public sealed partial class PhoneNumber : IEquatable<PhoneNumber>
{
    /// <summary>
    /// Gets the phone number as a string.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PhoneNumber"/> class.
    /// </summary>
    /// <param name="value">The phone number string.</param>
    public PhoneNumber(string value)
    {
        ValidatePhoneNumberIsNotNullOrEmpty(value);
        ValidatePhoneNumberContainsOnlyValidCharacters(value);
        string extension = ExtractExtension(value);
        string mainDigits = TrimPhoneNumber(value);
        ValidatePhoneNumberLength(mainDigits);

        Value = string.IsNullOrEmpty(extension) ? mainDigits : $"{mainDigits}x{extension}";
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
            return $"+1 ({Value.Substring(1, 3)}) {Value.Substring(4, 3)}-{Value[7..]}";
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

    private static void ValidatePhoneNumberIsNotNullOrEmpty(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException(DomainErrorCode.PhoneCannotBeNullOrEmpty, "Phone number cannot be null or empty.");
        }
    }

    private static void ValidatePhoneNumberContainsOnlyValidCharacters(string value)
    {
        if (!PhoneValidationRegex().IsMatch(value))
        {
            throw new DomainException(DomainErrorCode.PhoneMustNotContainInvalidCharacters, "Phone number contains invalid characters.");
        }
    }

    private static string TrimPhoneNumber(string value)
    {
        return PhoneTrimmerRegex().Replace(value, "");
    }

    private static string ExtractExtension(string value)
    {
        Match extMatch = ExtensionRegex().Match(value);
        string extension = extMatch.Success ? extMatch.Groups[1].Value : string.Empty;
        return extension;
    }

    private static void ValidatePhoneNumberLength(string mainDigits)
    {
        if (mainDigits.Length is not 10 and not 11)
        {
            throw new DomainException(DomainErrorCode.PhoneMustBe10Or11Digits, "Phone number must be 10 or 11 digits.");
        }
    }

    [GeneratedRegex(@"^[\d\s\-\(\)\+xXextEXT\./]+$")]
    private static partial Regex PhoneValidationRegex();

    [GeneratedRegex("[^0-9]")]
    private static partial Regex PhoneTrimmerRegex();

    [GeneratedRegex(@"(?:x|ext)\s*(\d+)", RegexOptions.IgnoreCase)]
    private static partial Regex ExtensionRegex();
}
