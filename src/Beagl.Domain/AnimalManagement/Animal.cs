// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.AnimalManagement.ValueObjects;
using Beagl.Domain.Core;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Domain.AnimalManagement;

/// <summary>
/// Represents an animal in the system, including description, characteristics, and health folder.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="Animal"/> class.
/// </remarks>
public class Animal : AuditedAggregateRoot
{
    private Animal(
        Guid id,
        string name,
        Guid speciesId,
        Guid primaryBreedId,
        Guid? secondaryBreedId,
        Guid colorId,
        Gender gender,
        DateTimeOffset dateOfBirth,
        Photo? photo,
        Microchip? microchip,
        DangerousDog? dangerousDog,
        bool isAnAssistanceDog,
        bool isAnUnclawnedCat,
        OriginCityInfo? originCityInfo,
        string distinctiveDescription,
        Guid createdByUserId,
        DateTimeOffset createdAt,
        Guid? modifiedByUserId = null,
        DateTimeOffset? modifiedAt = null) : base(createdByUserId, createdAt, modifiedByUserId, modifiedAt)
    {
        Id = id;
        Name = name;
        SpeciesId = speciesId;
        PrimaryBreedId = primaryBreedId;
        SecondaryBreedId = secondaryBreedId;
        ColorId = colorId;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        Photo = photo;
        Microchip = microchip;
        DangerousDog = dangerousDog;
        IsAnAssistanceDog = isAnAssistanceDog;
        IsAnUnclawnedCat = isAnUnclawnedCat;
        OriginCityInfo = originCityInfo;
        DistinctiveDescription = distinctiveDescription;
    }

    /// <summary>
    /// Creates a new instance of <see cref="Animal"/>.
    /// </summary>
    /// <param name="name">The name of the animal.</param>
    /// <param name="speciesId">The species ID of the animal.</param>
    /// <param name="primaryBreedId">The primary breed ID of the animal.</param>
    /// <param name="secondaryBreedId">The secondary breed ID of the animal.</param>
    /// <param name="colorId">The color ID of the animal.</param>
    /// <param name="gender">The gender of the animal.</param>
    /// <param name="dateOfBirth">The date of birth of the animal.</param>
    /// <param name="photo">The photo of the animal as a value object.</param>
    /// <param name="microchip">The microchip information for the animal.</param>
    /// <param name="dangerousDog">The dangerous dog status and related information.</param>
    /// <param name="isAnAssistanceDog">Whether the animal is an assistance dog.</param>
    /// <param name="isAnUnclawnedCat">Whether the animal is an unclawned cat.</param>
    /// <param name="originCityInfo">The origin city information for the animal.</param>
    /// <param name="distinctiveDescription"></param>
    /// <param name="createdByUserId">The ID of the user who created the animal.</param>
    /// <param name="createdAt">The date and time when the animal was created.</param>
    public static Animal Create(
        string name,
        Guid speciesId,
        Guid primaryBreedId,
        Guid? secondaryBreedId,
        Guid colorId,
        Gender gender,
        DateTimeOffset dateOfBirth,
        Photo? photo,
        Microchip? microchip,
        DangerousDog? dangerousDog,
        bool isAnAssistanceDog,
        bool isAnUnclawnedCat,
        OriginCityInfo? originCityInfo,
        string distinctiveDescription,
        Guid createdByUserId,
        DateTimeOffset createdAt)
    {
        // Add domain validation as needed for IDs
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Animal name is required.", nameof(name));
        if (speciesId == Guid.Empty)
            throw new ArgumentException("Species is required.", nameof(speciesId));
        if (primaryBreedId == Guid.Empty)
            throw new ArgumentException("Primary breed is required.", nameof(primaryBreedId));
        if (colorId == Guid.Empty)
            throw new ArgumentException("Color is required.", nameof(colorId));
        if (dateOfBirth > DateTimeOffset.UtcNow)
            throw new ArgumentException("Date of birth cannot be in the future.", nameof(dateOfBirth));
        // Assistance dog logic can be checked with a domain service if needed
        return new Animal(
            Guid.NewGuid(),
            name,
            speciesId,
            primaryBreedId,
            secondaryBreedId,
            colorId,
            gender,
            dateOfBirth,
            photo,
            microchip,
            dangerousDog,
            isAnAssistanceDog,
            isAnUnclawnedCat,
            originCityInfo,
            distinctiveDescription,
            createdByUserId,
            createdAt);
    }

    /// <summary>
    /// Rehydrates an existing <see cref="Animal"/> from persistence.
    /// </summary>
    /// <param name="id">The unique identifier of the animal.</param>
    /// <param name="name">The name of the animal.</param>
    /// <param name="speciesId">The species ID of the animal.</param>
    /// <param name="primaryBreedId">The primary breed ID of the animal.</param>
    /// <param name="secondaryBreedId">The secondary breed ID of the animal.</param>
    /// <param name="colorId">The color ID of the animal.</param>
    /// <param name="distinctiveDescription">The distinctive description of the animal.</param>
    /// <param name="createdByUserId">The ID of the user who created the animal.</param>
    /// <param name="createdAt">The date and time when the animal was created.</param>
    /// <param name="modifiedByUserId">The ID of the user who last modified the animal.</param>
    /// <param name="modifiedAt">The date and time when the animal was last modified.</param>
    /// <param name="gender">The gender of the animal.</param>
    /// <param name="dateOfBirth">The date of birth of the animal.</param>
    /// <param name="photo">The photo of the animal as a value object.</param>
    /// <param name="microchip">The microchip information for the animal.</param>
    /// <param name="dangerousDog">The dangerous dog status and related information.</param>
    /// <param name="isAnAssistanceDog">Whether the animal is an assistance dog.</param>
    /// <param name="isAnUnclawnedCat">Whether the animal is an unclawned cat.</param>
    /// <param name="originCityInfo">The origin city information for the animal.</param>
    public static Animal Rehydrate(
        Guid id,
        string name,
        Guid speciesId,
        Guid primaryBreedId,
        Guid? secondaryBreedId,
        Guid colorId,
        Gender gender,
        DateTimeOffset dateOfBirth,
        Photo? photo,
        Microchip? microchip,
        DangerousDog? dangerousDog,
        bool isAnAssistanceDog,
        bool isAnUnclawnedCat,
        OriginCityInfo? originCityInfo,
        string distinctiveDescription,
        Guid createdByUserId,
        DateTimeOffset createdAt,
        Guid? modifiedByUserId = null,
        DateTimeOffset? modifiedAt = null)
    {
        return new(
            id,
            name,
            speciesId,
            primaryBreedId,
            secondaryBreedId,
            colorId,
            gender,
            dateOfBirth,
            photo,
            microchip,
            dangerousDog,
            isAnAssistanceDog,
            isAnUnclawnedCat,
            originCityInfo,
            distinctiveDescription,
            createdByUserId,
            createdAt,
            modifiedByUserId,
            modifiedAt);
    }

    /// <summary>
    /// Gets or sets the name of the animal.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the species ID of the animal.
    /// </summary>
    public Guid SpeciesId { get; private set; }

    /// <summary>
    /// Gets the primary breed ID of the animal.
    /// </summary>
    public Guid PrimaryBreedId { get; private set; }

    /// <summary>
    /// Gets the secondary breed ID of the animal, if any.
    /// </summary>
    public Guid? SecondaryBreedId { get; private set; }

    /// <summary>
    /// Gets the color ID of the animal.
    /// </summary>
    public Guid ColorId { get; private set; }

    /// <summary>
    /// Gets or sets the description of the animal.
    /// </summary>
    public string? DistinctiveDescription { get; private set; }

    /// <summary>
    /// Gets or sets the gender of the animal.
    /// </summary>
    public Gender Gender { get; private set; }

    /// <summary>
    /// Gets or sets the date of birth of the animal.
    /// </summary>
    public DateTimeOffset DateOfBirth { get; private set; }

    /// <summary>
    /// Gets or sets the animal's photo as a value object.
    /// </summary>
    public Photo? Photo { get; private set; }

    /// <summary>
    /// Gets or sets the microchip information for the animal.
    /// </summary>
    public Microchip? Microchip { get; private set; }

    /// <summary>
    /// Gets or sets the dangerous dog status and related information.
    /// </summary>
    public DangerousDog? DangerousDog { get; private set; }

    /// <summary>
    /// Gets or sets whether the animal is an assistance dog.
    /// </summary>
    public bool IsAnAssistanceDog { get; private set; }

    /// <summary>
    /// Gets or sets whether the animal is an unclawned cat.
    /// </summary>
    public bool IsAnUnclawnedCat { get; private set; }

    /// <summary>
    /// Gets or sets the origin city information for the animal.
    /// </summary>
    public OriginCityInfo? OriginCityInfo { get; private set; }
}
