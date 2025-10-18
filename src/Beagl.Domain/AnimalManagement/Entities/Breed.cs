// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.Core;

namespace Beagl.Domain.AnimalManagement.Entities;

/// <summary>
/// Represents a breed available for animals in the domain.
/// </summary>
public sealed class Breed : Entity
{
    /// <summary>
    /// Gets the name of the breed.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the species ID this breed is available for.
    /// </summary>
    public int SpeciesId { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Breed"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the breed.</param>
    /// <param name="name">The name of the breed.</param>
    /// <param name="speciesId">The species ID this breed is available for.</param>
    public Breed(Guid id, string name, int speciesId)
    {
        Id = id;
        Name = name;
        SpeciesId = speciesId;
    }
}
