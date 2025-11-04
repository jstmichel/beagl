// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.ComponentModel.DataAnnotations;
using Beagl.WebApp.Resources.Pages.Animals;

namespace Beagl.WebApp.Pages.Animals.ViewModels;

/// <summary>
/// ViewModel for creating a cat.
/// </summary>
public sealed class CreateCatViewModel
{
    /// <summary>
    /// Gets or sets the name of the animal.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(CreateCat), ErrorMessageResourceName = "Error_Required_Name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the selected primary breed ID.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(CreateCat), ErrorMessageResourceName = "Error_Required_BreedPrimaryId")]
    public Guid? BreedPrimaryId { get; set; }

    /// <summary>
    /// Gets or sets the selected color ID.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(CreateCat), ErrorMessageResourceName = "Error_Required_ColorId")]
    public Guid? ColorId { get; set; }

    /// <summary>
    /// Gets or sets the distinctive description of the animal.
    /// </summary>
    public string? Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the gender of the animal.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(CreateCat), ErrorMessageResourceName = "Error_Required_Gender")]
    public int Gender { get; set; } = 0;

    /// <summary>
    /// Gets or sets the birth date of the animal.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(CreateCat), ErrorMessageResourceName = "Error_Required_BirthDate")]
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
    [Required(ErrorMessageResourceType = typeof(CreateCat), ErrorMessageResourceName = "Error_Required_Weight")]
    public decimal Weight { get; set; }

    /// <summary>
    /// Gets or sets the weight unit.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(CreateCat), ErrorMessageResourceName = "Error_Required_WeightUnit")]
    public int WeightUnit { get; set; } = 0;

    /// <summary>
    /// Gets or sets whether the cat is an unclawned cat.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(CreateCat), ErrorMessageResourceName = "Error_Required_IsAnUnclawnedCat")]
    public bool IsAnUnclawnedCat { get; set; }

    /// <summary>
    /// Gets or sets the medal assigned to the cat.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(CreateCat), ErrorMessageResourceName = "Error_Required_Medal")]
    public string? Medal { get; set; }

    /// <summary>
    /// Gets or sets whether the animal is sterilized.
    /// </summary>
    public bool IsSterilized { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the animal is vaccinated for rabies.
    /// </summary>
    public bool IsRabiesVaccinated { get; set; }

    /// <summary>
    /// Gets or sets the date of rabies vaccination. Required if <see cref="IsRabiesVaccinated"/> is true.
    /// </summary>
    public DateTimeOffset? RabiesVaccinationDate { get; set; }
}
