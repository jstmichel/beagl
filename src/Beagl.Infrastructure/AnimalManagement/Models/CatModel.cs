// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Infrastructure.AnimalManagement.Models;

/// <summary>
/// Persistence model for cat-specific data (TPT).
/// </summary>
public class CatModel : AnimalModel
{
    /// <summary>
    /// Gets or sets whether the cat is unclawned.
    /// </summary>
    public bool IsAnUnclawnedCat { get; set; }
}
