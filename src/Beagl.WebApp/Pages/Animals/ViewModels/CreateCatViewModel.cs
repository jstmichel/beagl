// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.ComponentModel.DataAnnotations;

namespace Beagl.WebApp.Pages.Animals.ViewModels;

/// <summary>
/// ViewModel for creating a cat.
/// </summary>
public sealed class CreateCatViewModel
{
    /// <summary>
    /// Gets or sets the name of the animal.
    /// </summary>
    [Required(ErrorMessage = "Please enter the cat's name.")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the selected primary breed ID.
    /// </summary>
    [Required(ErrorMessage = "Please select a breed.")]
    public Guid? BreedPrimaryId { get; set; }

    /// <summary>
    /// Gets or sets the selected color ID.
    /// </summary>
    [Required(ErrorMessage = "Please select a color.")]
    public Guid? ColorId { get; set; }

    /// <summary>
    /// Gets or sets the distinctive description of the animal.
    /// </summary>
    public string? Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the gender of the animal.
    /// </summary>
    [Required(ErrorMessage = "Please select a gender.")]
    public int Gender { get; set; } = 0;

    /// <summary>
    /// Gets or sets the birth date of the animal.
    /// </summary>
    [Required(ErrorMessage = "Please enter the cat's birth date.")]
    public DateTimeOffset? BirthDate { get; set; }

    /// <summary>
    /// Gets or sets the photo as a base64-encoded PNG image.
    /// </summary>
    public string? PhotoBase64 { get; set; }

    /// <summary>
    /// Gets or sets the microchip identifier.
    /// </summary>
    public string? MicrochipNumber { get; set; }

    /// <summary>
    /// Gets or sets the weight of the cat in pounds.
    /// </summary>
    [Required(ErrorMessage = "Please enter the cat's weight.")]
    public decimal Weight { get; set; }

    /// <summary>
    /// Gets or sets the weight unit.
    /// </summary>
    [Required(ErrorMessage = "Please select a weight unit.")]
    public int WeightUnit { get; set; } = 0;

    /// <summary>
    /// Gets or sets whether the cat is an unclawned cat.
    /// </summary>
    [Required(ErrorMessage = "Please specify if the cat is unclawned.")]
    public bool IsAnUnclawnedCat { get; set; }
}
