// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Application.Core.DTOs;
using Beagl.Domain.AnimalManagement.Enums;

namespace Beagl.Application.AnimalManagement.DTOs;

/// <summary>
/// Data Transfer Object for Animal aggregate.
/// </summary>
public class AnimalListDto : AuditedDtoBase
{
    /// <summary>
    /// Gets or sets the unique identifier of the animal.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the animal.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the species of the animal.
    /// </summary>
    public SpeciesType Species { get; set; } = SpeciesType.Unknown;

    /// <summary>
    /// Gets or sets the breed of the animal.
    /// </summary>
    public string PrimaryBreed { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the color of the animal.
    /// </summary>
    public string Color { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the distinctive description of the animal.
    /// </summary>
    public string? DistinctiveDescription { get; set; }

    /// <summary>
    /// Gets or sets the gender of the animal.
    /// </summary>
    public Gender Gender { get; set; } = Gender.Unknown;

    /// <summary>
    /// Gets or sets the birth date of the animal.
    /// </summary>
    public DateTimeOffset BirthDate { get; set; }

    /// <summary>
    /// Gets or sets the microchip identifier.
    /// </summary>
    public string? MicrochipNumber { get; set; }

    /// <summary>
    /// Gets or sets the URL of the animal's image.
    /// </summary>
    public string? Base64PngImage { get; set; }

    /// <summary>
    /// Gets or sets the weight of the animal.
    /// </summary>
    public decimal? Weight { get; set; }

    /// <summary>
    /// Gets or sets the weight unit of the animal.
    /// </summary>
    public WeightUnit WeightUnit { get; set; } = WeightUnit.Kilograms;

    /// <summary>
    /// Gets or sets the permit number of the animal.
    /// </summary>
    public string? PermitNumber { get; set; }
}
