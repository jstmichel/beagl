// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Beagl.Domain.AnimalManagement.ValueObjects;

namespace Beagl.Domain.AnimalManagement.Entities;

/// <summary>
/// Represents a color available for animals, related to a species.
/// </summary>
[Table("Colors")]
public class Color
{
    /// <summary>
    /// Gets or sets the unique identifier for the color.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the color.
    /// </summary>
    [Required]
    [MaxLength(64)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the species type this color is available for.
    /// </summary>
    public SpeciesType SpeciesType { get; set; }
}
