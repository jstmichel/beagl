// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beagl.Infrastructure.AnimalManagement.Models;

/// <summary>
/// Represents a color available for animals, related to a species.
/// </summary>
[Table("Colors")]
public class ColorModel
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
    /// Gets or sets the foreign key to the species this color is available for.
    /// </summary>
    [ForeignKey("Species")]
    public Guid SpeciesId { get; set; }

    /// <summary>
    /// Gets or sets the related species entity.
    /// </summary>
    public SpeciesModel? Species { get; set; }
}
