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
        string name,
        string species,
        Breed breed,
        string color,
        Gender gender,
        DateTimeOffset dateOfBirth,
        Photo? photo,
        Microchip? microchip,
        DangerousDog? dangerousDog,
        bool isAnAssistanceDog,
        bool isAnUnclawnedCat,
        OriginCityInfo? originCityInfo,
        Guid userId,
        DateTimeOffset createdAt) : base(userId, createdAt)
    {
        Name = name;
        Species = species;
        Breed = breed;
        Color = color;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        Photo = photo;
        Microchip = microchip;
        DangerousDog = dangerousDog;
        IsAnAssistanceDog = isAnAssistanceDog;
        IsAnUnclawnedCat = isAnUnclawnedCat;
        OriginCityInfo = originCityInfo;
    }

    /// <summary>
    /// Creates a new instance of <see cref="Animal"/>.
    /// </summary>
    /// <param name="name">The name of the animal.</param>
    /// <param name="species">The species of the animal.</param>
    /// <param name="breed">The breed information for the animal.</param>
    /// <param name="color">The color of the animal.</param>
    /// <param name="gender">The gender of the animal.</param>
    /// <param name="dateOfBirth">The date of birth of the animal.</param>
    /// <param name="userId">The identifier of the user who created the record.</param>
    /// <param name="createdAt">The date and time when the record was created.</param>
    /// <param name="photo">The photo of the animal as a value object.</param>
    /// <param name="microchip">The microchip information for the animal.</param>
    /// <param name="dangerousDog">The dangerous dog status and related information.</param>
    /// <param name="isAnAssistanceDog">Whether the animal is an assistance dog.</param>
    /// <param name="isAnUnclawnedCat">Whether the animal is an unclawned cat.</param>
    /// <param name="originCityInfo">The origin city information for the animal.</param>
    public static Animal Create(
        string name,
        string species,
        Breed breed,
        string color,
        Gender gender,
        DateTimeOffset dateOfBirth,
        Guid userId,
        DateTimeOffset createdAt,
        Photo? photo = null,
        Microchip? microchip = null,
        DangerousDog? dangerousDog = null,
        bool isAnAssistanceDog = false,
        bool isAnUnclawnedCat = false,
        OriginCityInfo? originCityInfo = null)
    {
        // Add validation logic as needed
        return new Animal(name, species, breed, color, gender, dateOfBirth, photo, microchip, dangerousDog, isAnAssistanceDog, isAnUnclawnedCat, originCityInfo, userId, createdAt);
    }

    /// <summary>
    /// Gets or sets the name of the animal.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets or sets the species of the animal.
    /// </summary>
    public string Species { get; private set; }

    /// <summary>
    /// Gets or sets the breed information for the animal.
    /// </summary>
    public Breed Breed { get; private set; }

    /// <summary>
    /// Gets or sets the color of the animal.
    /// </summary>
    public string Color { get; private set; }

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
