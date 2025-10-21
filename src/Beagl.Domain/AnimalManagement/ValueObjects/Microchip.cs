// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents a microchip identifier for an animal.
/// </summary>
public class Microchip
{
    /// <summary>
    /// Gets the microchip value.
    /// </summary>
    public string Value { get; private set; }

    private Microchip(string value) => Value = value;

    /// <summary>
    /// Creates a Microchip value object from the given string.
    /// </summary>
    public static Microchip? From(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;
        // Optionally: add format validation here
        return new Microchip(value);
    }
}
