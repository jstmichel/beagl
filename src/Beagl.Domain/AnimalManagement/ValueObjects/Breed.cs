// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents the breed information for an animal.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="Breed"/> class.
/// </remarks>
/// <param name="primary">The primary breed.</param>
/// <param name="secondary">The secondary breed, if any.</param>
public sealed class Breed(string primary, string? secondary = null)
{
    /// <summary>
    /// Gets the primary breed of the animal.
    /// </summary>
    public string Primary { get; } = primary;

    /// <summary>
    /// Gets the secondary breed of the animal, if any.
    /// </summary>
    public string? Secondary { get; } = secondary;
}
