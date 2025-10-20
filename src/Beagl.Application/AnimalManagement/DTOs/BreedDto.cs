// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Application.AnimalManagement.DTOs;

/// <summary>
/// Data transfer object for animal breed dropdowns.
/// </summary>
public sealed class BreedDto
{
    /// <summary>
    /// Gets or sets the unique identifier for the breed.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the species ID associated with this breed.
    /// </summary>
    public Guid SpeciesId { get; set; }

    /// <summary>
    /// Gets or sets the name of the breed.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
