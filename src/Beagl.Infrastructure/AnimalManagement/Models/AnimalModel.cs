// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.AnimalManagement.ValueObjects;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Infrastructure.AnimalManagement.Models;

/// <summary>
/// Persistence model for Animal aggregate, using value objects.
/// </summary>
public class AnimalModel
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
    /// Gets or sets the foreign key for the species of the animal.
    /// </summary>
    public Guid SpeciesId { get; set; }

    /// <summary>
    /// Gets or sets the related species entity.
    /// </summary>
    public SpeciesModel? Species { get; set; }


    /// <summary>
    /// Gets or sets the foreign key for the primary breed of the animal.
    /// </summary>
    public Guid PrimaryBreedId { get; set; }

    /// <summary>
    /// Gets or sets the related primary breed entity.
    /// </summary>
    public BreedModel? PrimaryBreed { get; set; }

    /// <summary>
    /// Gets or sets the foreign key for the secondary breed of the animal (optional).
    /// </summary>
    public Guid? SecondaryBreedId { get; set; }

    /// <summary>
    /// Gets or sets the related secondary breed entity.
    /// </summary>
    public BreedModel? SecondaryBreed { get; set; }


    /// <summary>
    /// Gets or sets the foreign key for the color of the animal.
    /// </summary>
    public Guid ColorId { get; set; }

    /// <summary>
    /// Gets or sets the related color entity.
    /// </summary>
    public ColorModel? Color { get; set; }

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
    public Audit<Guid> Created { get; set; } = new Audit<Guid>(Guid.Empty, DateTimeOffset.MinValue);

    /// <summary>
    /// Gets the audit information for last modification.
    /// </summary>
    public Audit<Guid>? Modified { get; set; } = new Audit<Guid>(Guid.Empty, DateTimeOffset.MinValue);
}
