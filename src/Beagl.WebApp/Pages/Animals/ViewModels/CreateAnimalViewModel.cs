// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.ComponentModel.DataAnnotations;

namespace Beagl.WebApp.Pages.Animals.ViewModels;

/// <summary>
/// ViewModel for creating an animal.
/// </summary>
internal class CreateAnimalViewModel
{
    /// <summary>
    /// Gets or sets the name of the animal.
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the selected primary breed ID.
    /// </summary>
    [Required]
    public Guid BreedPrimaryId { get; set; }

    /// <summary>
    /// Gets or sets the selected color ID.
    /// </summary>
    [Required]
    public Guid ColorId { get; set; }

    /// <summary>
    /// Gets or sets the distinctive description of the animal.
    /// </summary>
    public string? Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the gender of the animal.
    /// </summary>
    [Required]
    public string Gender { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the birth date of the animal.
    /// </summary>
    [Required]
    public DateTimeOffset BirthDate { get; set; }

    /// <summary>
    /// Gets or sets the photo as a base64-encoded PNG image.
    /// </summary>
    public string? PhotoBase64 { get; set; }

    /// <summary>
    /// Gets or sets the microchip identifier.
    /// </summary>
    public string? MicrochipNumber { get; set; }
}
