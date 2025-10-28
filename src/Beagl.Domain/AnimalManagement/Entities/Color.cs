// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.AnimalManagement.Enums;

namespace Beagl.Domain.AnimalManagement.Entities;

/// <summary>
/// Represents a color available for animals, related to a species.
/// </summary>
public class Color
{
    /// <summary>
    /// Gets or sets the unique identifier for the color.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the color.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the species type this color is available for.
    /// </summary>
    public SpeciesType SpeciesType { get; set; }
}
