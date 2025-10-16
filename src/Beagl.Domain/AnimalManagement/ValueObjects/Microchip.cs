// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents a microchip identifier for an animal.
/// </summary>
public sealed class Microchip(string value)
{
    /// <summary>
    /// Gets the microchip identifier value.
    /// </summary>
    public string Value { get; } = value;
}
