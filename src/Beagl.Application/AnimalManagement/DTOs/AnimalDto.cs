// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Collections.Generic;
using Beagl.Application.Core.DTOs;

namespace Beagl.Application.AnimalManagement.DTOs;

/// <summary>
/// Data Transfer Object for Animal aggregate.
/// </summary>
public class AnimalDto : AuditedDtoBase
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
    public string? Species { get; set; }

    /// <summary>
    /// Gets or sets the breed of the animal.
    /// </summary>
    public string? Breed { get; set; }

    /// <summary>
    /// Gets or sets the color of the animal.
    /// </summary>
    public string? Color { get; set; }

    /// <summary>
    /// Gets or sets the distinctive description of the animal.
    /// </summary>
    public string? DistinctiveDescription { get; set; }

    /// <summary>
    /// Gets or sets the gender of the animal.
    /// </summary>
    public string? Gender { get; set; }

    /// <summary>
    /// Gets or sets the birth date of the animal.
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// Gets or sets the photo as a base64-encoded PNG image.
    /// </summary>
    public string? PhotoBase64 { get; set; }

    /// <summary>
    /// Gets or sets the microchip identifier.
    /// </summary>
    public string? MicrochipNumber { get; set; }

    /// <summary>
    /// Gets or sets the permit number.
    /// </summary>
    public string? PermitNumber { get; set; }

    /// <summary>
    /// Gets or sets the dangerous dog status.
    /// </summary>
    public bool IsDangerousDog { get; set; }

    /// <summary>
    /// Gets or sets whether the animal is an assistance dog.
    /// </summary>
    public bool IsAnAssistanceDog { get; set; }

    /// <summary>
    /// Gets or sets whether the animal is an unclawned cat.
    /// </summary>
    public bool IsAnUnclawnedCat { get; set; }

    /// <summary>
    /// Gets a value indicating whether the animal comes from another city.
    /// </summary>
    public bool? ComesFromAnotherCity { get; set; }

    /// <summary>
    /// Gets the name of the city the animal comes from.
    /// </summary>
    public string? CityName { get; set; }

    /// <summary>
    /// Gets a value indicating whether the animal had a judgment in that city.
    /// </summary>
    public bool? HadJudgmentInThatCity { get; set; }

    /// <summary>
    /// Gets or sets the collection of health records for the animal.
    /// </summary>
    public ICollection<HealthRecordDto> HealthRecords { get; init; } = [];

    /// <summary>
    /// Gets or sets the collection of medal records for the animal.
    /// </summary>
    public ICollection<MedalRecordDto> MedalRecords { get; init; } = [];
}
