// MIT License - Copyright (c) 2025 Jonathan St-Michel

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
}
