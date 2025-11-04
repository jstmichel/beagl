// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.CitizenManagement.Enums;

namespace Beagl.Domain.CitizenManagement.ValueObjects;

/// <summary>
/// Represents a person's name.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="PersonName"/> class.
/// </remarks>
public class PersonName(Civility civility, string firstName, string lastName)
{

    /// <summary>
    /// Gets or sets the civility (title) of the person.
    /// </summary>
    public Civility Civility { get; set; } = civility;

    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    public string FirstName { get; set; } = firstName;

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    public string LastName { get; set; } = lastName;

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
}
