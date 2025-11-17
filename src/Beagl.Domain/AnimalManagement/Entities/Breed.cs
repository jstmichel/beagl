// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.AnimalManagement.Enums;
using Beagl.Domain.Core;

namespace Beagl.Domain.AnimalManagement.Entities;

/// <summary>
/// Represents a breed available for animals, related to a species.
/// </summary>
public sealed class Breed : Entity
{
    /// <summary>
    /// Gets or sets the name of the breed.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the species type this breed is available for.
    /// </summary>
    public SpeciesType SpeciesType { get; private set; }

    /// <summary>
    /// Private parameterless constructor for EF Core.
    /// </summary>
    private Breed() { }

    /// <summary>
    /// Public constructor to create a new Breed instance.
    /// </summary>
    /// <param name="name">The name of the breed.</param>
    /// <param name="speciesType">The species type this breed is available for.</param>
    /// <returns>A new instance of <see cref="Breed"/>.</returns>
    public Breed(string name, SpeciesType speciesType)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

        Id = Guid.NewGuid();
        Name = name;
        SpeciesType = speciesType;
    }
}
