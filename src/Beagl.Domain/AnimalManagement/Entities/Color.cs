// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.Core;

namespace Beagl.Domain.AnimalManagement.Entities;

/// <summary>
/// Represents a color available for animals in the domain.
/// </summary>
public sealed class Color : Entity
{
    /// <summary>
    /// Gets the name of the color.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the species ID this color is available for.
    /// </summary>
    public Guid SpeciesId { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Color"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the color.</param>
    /// <param name="name">The name of the color.</param>
    /// <param name="speciesId">The species ID this color is available for.</param>
    public Color(Guid id, string name, Guid speciesId)
    {
        Id = id;
        Name = name;
        SpeciesId = speciesId;
    }
}
