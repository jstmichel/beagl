// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents the weight of an animal, including value and unit.
/// </summary>
public record class Weight(decimal Value, WeightUnit Unit = WeightUnit.Kilograms);
