// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.AnimalManagement.Enums;

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents the weight of an animal, including value and unit.
/// </summary>
public class Weight
{
    /// <summary>
    /// Gets the weight value.
    /// </summary>
	public decimal Value { get; private set; }

    /// <summary>
    /// Gets the weight unit.
    /// </summary>
	public WeightUnit Unit { get; private set; }

    private Weight(decimal value, WeightUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    /// <summary>
    /// Creates a Weight value object from the given value and unit.
    /// </summary>
    /// <param name="value">The weight value.</param>
    /// <param name="unit">The weight unit.</param>
    /// <returns>A Weight value object or null if the input is invalid.</returns>
    public static Weight From(decimal? value, WeightUnit? unit = null)
    {
        if (value is null || value <= 0)
            return new Weight(0, WeightUnit.Kilograms);
        return new Weight(value.Value, unit ?? WeightUnit.Kilograms);
    }
}
