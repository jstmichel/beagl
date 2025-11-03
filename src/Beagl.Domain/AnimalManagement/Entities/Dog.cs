// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.AnimalManagement.Enums;
using Beagl.Domain.AnimalManagement.ValueObjects;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Domain.AnimalManagement.Entities;

/// <summary>
/// Persistence model for dog-specific data (TPT).
/// </summary>
public sealed class Dog : Animal
{
    /// <summary>
    /// Gets or sets the foreign key for the secondary breed of the animal (optional).
    /// </summary>
    public Guid? SecondaryBreedId { get; private set; }

    /// <summary>
    /// Gets or sets the related secondary breed entity.
    /// </summary>
    public Breed? SecondaryBreed { get; private set; }

    /// <summary>
    /// Gets or sets the dangerous dog status and related information.
    /// </summary>
    public DangerousDog? DangerousDog { get; private set; }

    /// <summary>
    /// Gets or sets whether the dog is an assistance dog.
    /// </summary>
    public bool IsAnAssistanceDog { get; private set; }

    /// <summary>
    /// Gets or sets the origin city information for the animal.
    /// </summary>
    public OriginCityInfo? OriginCityInfo { get; private set; }

    /// <summary>
    /// Private parameterless constructor for EF Core.
    /// </summary>
    private Dog() { }

    /// <summary>
    /// Public constructor to create a new Dog aggregate with all fields.
    /// </summary>
    public Dog(
        SpeciesType speciesType,
        string name,
        Guid primaryBreedId,
        Guid colorId,
        string? distinctiveDescription,
        Gender gender,
        DateTimeOffset dateOfBirth,
        Photo? photo,
        Microchip? microchip,
        Weight weight,
        Audit<Guid> created,
        Guid? secondaryBreedId,
        DangerousDog? dangerousDog,
        bool isAnAssistanceDog,
        OriginCityInfo? originCityInfo,
        Medal? medal)
        : base(speciesType, name, primaryBreedId, colorId, distinctiveDescription, gender, dateOfBirth, photo, microchip, weight, medal, created)
    {
        SecondaryBreedId = secondaryBreedId;
        DangerousDog = dangerousDog;
        IsAnAssistanceDog = isAnAssistanceDog;
        OriginCityInfo = originCityInfo;
    }
}
