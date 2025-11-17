// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.CitizenManagement.Enums;
using Beagl.Domain.Core.Exceptions;

namespace Beagl.Domain.CitizenManagement.ValueObjects;

/// <summary>
/// Represents a person's name.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="PersonName"/> class.
/// </remarks>
public sealed class PersonName : IEquatable<PersonName>
{

    /// <summary>
    /// Gets the civility (title) of the person.
    /// </summary>
    public Civility Civility { get; }

    /// <summary>
    /// Gets the first name.
    /// </summary>
    public string FirstName { get; }

    /// <summary>
    /// Gets the last name.
    /// </summary>
    public string LastName { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PersonName"/> class.
    /// </summary>
    /// <param name="civility">The civility (title) of the person.</param>
    /// <param name="firstName">The first name.</param>
    /// <param name="lastName">The last name.</param>
    /// <exception cref="PersonNameDomainException">Thrown when firstName or lastName is null or empty.</exception>
    public PersonName(Civility civility, string firstName, string lastName)
    {
        PersonNameDomainException.ThrowIfNullOrEmpty(firstName, nameof(firstName));
        PersonNameDomainException.ThrowIfNullOrEmpty(lastName, nameof(lastName));
        ValidateFirstName(firstName);
        ValidateLastName(lastName);

        Civility = civility;
        FirstName = firstName;
        LastName = lastName;
    }

    /// <inheritdoc/>
    public bool Equals(PersonName? other)
    {
        if (other is null)
            return false;

        return Civility == other.Civility &&
               FirstName == other.FirstName &&
               LastName == other.LastName;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as PersonName);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Civility, FirstName, LastName);

    /// <summary>
    /// Equality operator for PersonName.
    /// </summary>
    public static bool operator ==(PersonName? left, PersonName? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Inequality operator for PersonName.
    /// </summary>
    public static bool operator !=(PersonName? left, PersonName? right)
    {
        return !Equals(left, right);
    }

    /// <summary>
    /// Returns the full name as a display string.
    /// </summary>
    /// <returns>The full name in "FirstName LastName" format.</returns>
    public string ToDisplayString() => $"{FirstName} {LastName}";

    /// <summary>
    /// Returns the civility as a string.
    /// </summary>
    /// <returns>The civility as a string.</returns>
    public string CivilityAsString()
    {
        return Civility switch
        {
            Civility.Mr => "Mr.",
            Civility.Mrs => "Mrs.",
            Civility.Ms => "Ms.",
            Civility.Dr => "Dr.",
            Civility.Prof => "Prof.",
            Civility.Mx => "Mx.",
            _ => string.Empty
        };
    }

    /// <summary>
    /// Creates a PersonName instance from a string, returning null if the string is null or whitespace.
    /// </summary>
    public static PersonName? From(Civility civility, string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
        {
            return null;
        }

        return new PersonName(civility, firstName, lastName);
    }

    private static void ValidateLastName(string lastName)
    {
        if (lastName.Length > 100)
        {
            throw new PersonNameDomainException("Last name cannot exceed 100 characters.");
        }
    }

    private static void ValidateFirstName(string firstName)
    {
        if (firstName.Length > 100)
        {
            throw new PersonNameDomainException("First name cannot exceed 100 characters.");
        }
    }
}
