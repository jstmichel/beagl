// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.AnimalManagement.Entities;

/// <summary>
/// Persistence model for cat-specific data (TPT).
/// </summary>
public class Cat : Animal
{
    /// <summary>
    /// Gets or sets whether the cat is unclawned.
    /// </summary>
    public bool IsAnUnclawnedCat { get; set; }
}
