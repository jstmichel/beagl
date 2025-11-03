// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Application.AnimalManagement.DTOs;

/// <summary>
/// Data transfer object for creating a new dog.
/// </summary>
public class CreateDogDto
{
    /// <summary>
    /// Gets or sets the name of the animal.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the selected primary breed ID.
    /// </summary>
    public Guid BreedPrimaryId { get; set; }

    /// <summary>
    /// Gets or sets the selected secondary breed ID.
    /// </summary>
    public Guid? BreedSecondaryId { get; set; }

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
    /// Gets or sets the weight of the dog in pounds.
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
}
