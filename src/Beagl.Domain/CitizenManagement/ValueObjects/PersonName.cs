// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.CitizenManagement.ValueObjects;

/// <summary>
/// Represents a person's name.
/// </summary>
public class PersonName
{
    /// <summary>
    /// Gets or sets the civility (title) of the person.
    /// </summary>
    public Civility Civility { get; set; }

    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    public required string LastName { get; set; }
}
