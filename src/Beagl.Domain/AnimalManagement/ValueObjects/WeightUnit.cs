// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Enum for weight measurement units.
/// </summary>
public enum WeightUnit
{
    /// <summary>
    /// Represents weight in kilograms.
    /// </summary>
    Kilograms = 0,

    /// <summary>
    /// Represents weight in pounds.
    /// </summary>
    Pounds = 1
}

/// <summary>
/// Helper methods for the <see cref="WeightUnit"/> enum.
/// </summary>
public static class WeightUnitHelper
{
    /// <summary>
    /// Converts an integer to a <see cref="WeightUnit"/> enum value.
    /// </summary>
    public static WeightUnit FromInt(int value)
    {
        if (!Enum.IsDefined(typeof(WeightUnit), value))
            return WeightUnit.Kilograms;
        return (WeightUnit)value;
    }
}
