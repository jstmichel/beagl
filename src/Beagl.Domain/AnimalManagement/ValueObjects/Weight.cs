// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.AnimalManagement.Enums;
using Beagl.Domain.Core.Exceptions;

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents the weight of an animal, including value and unit.
/// </summary>
public class Weight : IEquatable<Weight>
{
    /// <summary>
    /// Gets the weight value.
    /// </summary>
	public decimal Value { get; }

    /// <summary>
    /// Gets the weight unit.
    /// </summary>
	public WeightUnit Unit { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Weight"/> class.
    /// </summary>
    /// <param name="value">The weight value.</param>
    /// <param name="unit">The weight unit.</param>
    /// <exception cref="InvalidWeightException">Thrown when value is less than or equal to zero.</exception>
    public Weight(decimal value, WeightUnit unit)
    {
        ValidateWeightIsPositive(value);

        Value = value;
        Unit = unit;
    }

    private static void ValidateWeightIsPositive(decimal value)
    {
        if (value <= 0)
        {
            throw new InvalidWeightException("Weight must be positive.");
        }
    }

    /// <inheritdoc/>
    public bool Equals(Weight? other) =>
        other is not null &&
        Value == other.Value &&
        Unit == other.Unit;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as Weight);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(
        Value,
        Unit);

    /// <summary>
    /// Equality operator for Weight value objects.
    /// </summary>
    /// <param name="left">The left Weight value.</param>
    /// <param name="right">The right Weight value.</param>
    /// <returns>True if both Weight values are equal; otherwise, false.</returns>
    public static bool operator ==(Weight? left, Weight? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Inequality operator for Weight value objects.
    /// </summary>
    /// <param name="left">The left Weight value.</param>
    /// <param name="right">The right Weight value.</param>
    /// <returns>True if both Weight values are not equal; otherwise, false.</returns>
    public static bool operator !=(Weight? left, Weight? right)
    {
        return !Equals(left, right);
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
