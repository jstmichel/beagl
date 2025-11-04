// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Application.AnimalManagement.DTOs;

/// <summary>
/// Data transfer object for creating a new cat.
/// </summary>
public class CreateCatDto : CreateAnimalDto
{
    /// <summary>
    /// Gets or sets whether the cat is an unclawned cat.
    /// </summary>
    public bool IsAnUnclawnedCat { get; set; }
}
