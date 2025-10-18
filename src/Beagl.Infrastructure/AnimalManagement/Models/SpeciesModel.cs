// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beagl.Infrastructure.AnimalManagement.Models;

/// <summary>
/// Represents a supported animal species (e.g., Cat, Dog).
/// </summary>
[Table("Species")]
public class SpeciesModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the species.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the species.
    /// </summary>
    [Required]
    [MaxLength(32)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the species is active.
    /// </summary>
    public bool IsActive { get; set; } = true;
}
