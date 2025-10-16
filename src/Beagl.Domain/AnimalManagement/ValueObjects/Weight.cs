// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents the weight of an animal, including value and unit.
/// </summary>
public class Weight
{
    /// <summary>
    /// Gets or sets the weight value.
    /// </summary>
    public decimal Value { get; set; }

    /// <summary>
    /// Gets or sets the unit of the weight (e.g., kg, lb).
    /// </summary>
    public string Unit { get; set; } = string.Empty;
}
