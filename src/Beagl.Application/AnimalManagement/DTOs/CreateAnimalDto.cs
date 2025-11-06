// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Application.AnimalManagement.DTOs;

/// <summary>
/// Base data transfer object for creating a new animal.
/// </summary>
public abstract class CreateAnimalDto
{
    /// <summary>
    /// Gets or sets the optional citizen ID of the owner.
    /// </summary>
    public Guid? CitizenId { get; set; }
    /// <summary>
    /// Gets or sets the name of the animal.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the selected primary breed ID.
    /// </summary>
    public Guid BreedPrimaryId { get; set; }

    /// <summary>
    /// Gets or sets the selected color ID.
    /// </summary>
    public Guid ColorId { get; set; }

    /// <summary>
    /// Gets or sets the distinctive description of the animal.
    /// </summary>
    public string? Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the gender of the animal.
    /// </summary>
    public int Gender { get; set; }

    /// <summary>
    /// Gets or sets the birth date of the animal.
    /// </summary>
    public DateTimeOffset BirthDate { get; set; }

    /// <summary>
    /// Gets or sets the weight of the cat in pounds.
    /// </summary>
    public decimal Weight { get; set; }

    /// <summary>
    /// Gets or sets the weight unit.
    /// </summary>
    public int WeightUnit { get; set; }

    /// <summary>
    /// Gets or sets the photo as a base64-encoded PNG image.
    /// </summary>
    public string? PhotoBase64 { get; set; }

    /// <summary>
    /// Gets or sets the microchip identifier.
    /// </summary>
    public string? MicrochipNumber { get; set; }

    /// <summary>
    /// Gets or sets the medal information.
    /// </summary>
    public string? Medal { get; set; }

    /// <summary>
    /// Gets or sets whether the animal is sterilized.
    /// </summary>
    public bool IsSterilized { get; set; }

    /// <summary>
    /// Gets a value indicating whether the animal is vaccinated for rabies.
    /// </summary>
    public bool IsRabiesVaccinated { get; set; }

    /// <summary>
    /// Gets the date of rabies vaccination. Required if <see cref="IsRabiesVaccinated"/> is true.
    /// </summary>
    public DateTimeOffset? RabiesVaccinationDate { get; set; }
}
