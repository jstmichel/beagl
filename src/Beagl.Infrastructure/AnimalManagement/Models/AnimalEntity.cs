// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.AnimalManagement.ValueObjects;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Infrastructure.AnimalManagement.Models;

/// <summary>
/// Persistence model for Animal aggregate, using value objects.
/// </summary>
public class AnimalEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the animal.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the animal.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Gets or sets the species of the animal.
    /// </summary>
    public string Species { get; set; } = default!;

    /// <summary>
    /// Gets or sets the breed information for the animal.
    /// </summary>
    public Breed Breed { get; set; } = default!;

    /// <summary>
    /// Gets or sets the color of the animal.
    /// </summary>
    public string Color { get; set; } = default!;

    /// <summary>
    /// Gets or sets the distinctive description of the animal.
    /// </summary>
    public string? DistinctiveDescription { get; set; }

    /// <summary>
    /// Gets or sets the gender of the animal.
    /// </summary>
    public Gender Gender { get; set; } = Gender.Unknown;

    /// <summary>
    /// Gets or sets the date of birth of the animal.
    /// </summary>
    public DateTimeOffset DateOfBirth { get; set; }

    /// <summary>
    /// Gets or sets the photo of the animal as a value object.
    /// </summary>
    public Photo? Photo { get; set; }

    /// <summary>
    /// Gets or sets the microchip information for the animal.
    /// </summary>
    public Microchip? Microchip { get; set; }

    /// <summary>
    /// Gets or sets the dangerous dog status and related information.
    /// </summary>
    public DangerousDog? DangerousDog { get; set; }

    /// <summary>
    /// Gets or sets whether the animal is an assistance dog.
    /// </summary>
    public bool IsAnAssistanceDog { get; set; }

    /// <summary>
    /// Gets or sets whether the animal is an unclawned cat.
    /// </summary>
    public bool IsAnUnclawnedCat { get; set; }

    /// <summary>
    /// Gets or sets the origin city information for the animal.
    /// </summary>
    public OriginCityInfo? OriginCityInfo { get; set; }

    /// <summary>
    /// Gets the audit information for creation.
    /// </summary>
    public Audit<Guid>? Created { get; set; }

    /// <summary>
    /// Gets the audit information for last modification.
    /// </summary>
    public Audit<Guid>? Modified { get; set; }

    /// <summary>
    /// Gets or sets the collection of health records associated with the animal.
    /// </summary>
    public ICollection<HealthRecordEntity> HealthRecords { get; } = [];

    /// <summary>
    /// Gets or sets the collection of medal records associated with the animal.
    /// </summary>
    public ICollection<MedalRecordEntity> MedalRecords { get; } = [];
}
