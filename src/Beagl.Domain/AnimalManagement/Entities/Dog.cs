// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.AnimalManagement.ValueObjects;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Domain.AnimalManagement.Entities;

/// <summary>
/// Dog aggregate root.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="Dog"/> class.
/// </remarks>
/// <param name="name">The dog's name.</param>
/// <param name="primaryBreedId">Primary breed identifier.</param>
/// <param name="colorId">Color identifier.</param>
/// <param name="gender">Gender of the dog.</param>
/// <param name="birthDate">Birth date of the dog.</param>
/// <param name="secondaryBreedId">Secondary breed identifier.</param>
/// <param name="dangerousDog">Dangerous dog status and info.</param>
/// <param name="isAnAssistanceDog">Whether the dog is an assistance dog.</param>
/// <param name="originCityInfo">Origin city info.</param>
/// <param name="photo">Optional photo.</param>
/// <param name="microchip">Optional microchip.</param>
/// <param name="distinctiveDescription">Distinctive description of the dog.</param>
/// <param name="createdByUserId">The user ID of the creator.</param>
/// <param name="createdAt">The creation date and time.</param>
/// <param name="modifiedByUserId">The user ID of the modifier.</param>
/// <param name="modifiedAt">The modification date and time.</param>
public sealed class Dog(
    string name,
    Guid primaryBreedId,
    Guid colorId,
    Gender gender,
    DateTimeOffset birthDate,
    Guid? secondaryBreedId,
    DangerousDog? dangerousDog,
    bool isAnAssistanceDog,
    OriginCityInfo? originCityInfo,
    Photo? photo,
    Microchip? microchip,
    string distinctiveDescription,
    Guid createdByUserId,
    DateTimeOffset createdAt,
    Guid? modifiedByUserId = null,
    DateTimeOffset? modifiedAt = null) : Animal(name, SpeciesType.Dog, primaryBreedId, colorId, gender, birthDate, photo, microchip, distinctiveDescription, createdByUserId, createdAt, modifiedByUserId, modifiedAt)
{

    /// <summary>
    /// Gets the secondary breed ID of the dog.
    /// </summary>
    public Guid? SecondaryBreedId { get; private set; } = secondaryBreedId;

    /// <summary>
    /// Gets the dangerous dog status and related information.
    /// </summary>
    public DangerousDog? DangerousDog { get; private set; } = dangerousDog;

    /// <summary>
    /// Gets a value indicating whether the dog is an assistance dog.
    /// </summary>
    public bool IsAnAssistanceDog { get; private set; } = isAnAssistanceDog;

    /// <summary>
    /// Gets the origin city information of the dog.
    /// </summary>
    public OriginCityInfo? OriginCityInfo { get; private set; } = originCityInfo;
}
