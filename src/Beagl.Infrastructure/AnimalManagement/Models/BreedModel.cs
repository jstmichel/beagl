// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beagl.Infrastructure.AnimalManagement.Models;

/// <summary>
/// Represents a breed available for animals, related to a species.
/// </summary>
[Table("Breeds")]
public class BreedModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the breed.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the breed.
    /// </summary>
    [Required]
    [MaxLength(64)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the species type this breed is available for.
    /// </summary>
    public SpeciesType SpeciesType { get; set; }
}
