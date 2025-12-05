// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Infrastructure.Core.Helpers;

/// <summary>
/// Helper methods for enum conversions.
/// </summary>
public static class EnumHelper
{
    /// <summary>
    /// Converts an integer to a specified enum type.
    /// </summary>
    public static TEnum FromInt<TEnum>(int value) where TEnum : Enum
    {
        if (!Enum.IsDefined(typeof(TEnum), value))
            throw new ArgumentException("Invalid enum value.", nameof(value));
        return (TEnum)(object)value;
    }
}
