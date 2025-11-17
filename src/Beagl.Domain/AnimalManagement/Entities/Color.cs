// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.AnimalManagement.Enums;
using Beagl.Domain.Core;

namespace Beagl.Domain.AnimalManagement.Entities;

/// <summary>
/// Represents a color available for animals, related to a species.
/// </summary>
public sealed class Color : Entity
{
    /// <summary>
    /// Gets or sets the name of the color.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the species type this color is available for.
    /// </summary>
    public SpeciesType SpeciesType { get; private set; }

    /// <summary>
    /// Private parameterless constructor for EF Core.
    /// </summary>
    private Color() { }

    /// <summary>
    /// Public constructor to create a new Color instance.
    /// </summary>
    /// <param name="name">The name of the color.</param>
    /// <param name="speciesType">The species type this color is available for.</param>
    /// <returns>A new instance of <see cref="Color"/>.</returns>
    public Color(string name, SpeciesType speciesType)
    {
        ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));

        Id = Guid.NewGuid();
        Name = name;
        SpeciesType = speciesType;
    }
}
