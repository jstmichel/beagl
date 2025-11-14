// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.ComponentModel.DataAnnotations;
using Beagl.WebApp.Resources.Pages.Animals;

namespace Beagl.WebApp.Pages.Animals.ViewModels;

/// <summary>
/// ViewModel for creating a dog.
/// </summary>
public sealed class CreateDogViewModel
{
    /// <summary>
    /// Gets or sets the name of the animal.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(CreateDog), ErrorMessageResourceName = "Error_Required_Name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the selected primary breed ID.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(CreateDog), ErrorMessageResourceName = "Error_Required_BreedPrimaryId")]
    public Guid? BreedPrimaryId { get; set; }

    /// <summary>
    /// Gets or sets the selected secondary breed ID.
    /// </summary>
    public Guid? BreedSecondaryId { get; set; }

    /// <summary>
    /// Gets or sets the selected color ID.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(CreateDog), ErrorMessageResourceName = "Error_Required_ColorId")]
    public Guid? ColorId { get; set; }

    /// <summary>
    /// Gets or sets the distinctive description of the animal.
    /// </summary>
    public string? Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the gender of the animal.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(CreateDog), ErrorMessageResourceName = "Error_Required_Gender")]
    public int Gender { get; set; } = 0;

    /// <summary>
    /// Gets or sets the birth date of the animal.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(CreateDog), ErrorMessageResourceName = "Error_Required_BirthDate")]
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
    /// Gets or sets the weight of the dog in pounds.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(CreateDog), ErrorMessageResourceName = "Error_Required_Weight")]
    public decimal Weight { get; set; }

    /// <summary>
    /// Gets or sets the weight unit.
    /// </summary>
    [Required(ErrorMessageResourceType = typeof(CreateDog), ErrorMessageResourceName = "Error_Required_WeightUnit")]
    public int WeightUnit { get; set; } = 0;

    /// <summary>
    /// Gets or sets the medal assigned to the dog.
    /// </summary>
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

    /// <summary>
    /// Gets or sets whether the dog is an assistance dog.
    /// </summary>
    public bool IsAnAssistanceDog { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the dog is considered dangerous.
    /// </summary>
    public bool IsDangerousDog { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the dog has responsibility insurance.
    /// </summary>
    public bool HasResponsibilityInsurance { get; set; }

    /// <summary>
    /// Gets or sets an optional comment about the dangerous dog status.
    /// </summary>
    public string? DangerousDogComment { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the animal comes from another city.
    /// </summary>
    public bool ComesFromAnotherCity { get; set; }

    /// <summary>
    /// Gets or sets the name of the city.
    /// </summary>
    public string? OriginCityName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the animal had a judgment in that city.
    /// </summary>
    public bool HadJudgmentInThatCity { get; set; }
}
