// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.AnimalManagement.ValueObjects;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Domain.AnimalManagement.Entities;

/// <summary>
/// Cat aggregate root.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="Cat"/> class.
/// </remarks>
/// <param name="name">The cat's name.</param>
/// <param name="primaryBreedId">Primary breed identifier.</param>
/// <param name="colorId">Color identifier.</param>
/// <param name="gender">Gender of the cat.</param>
/// <param name="birthDate">Birth date of the cat.</param>
/// <param name="isAnUnclawnedCat">Whether the cat is unclawned (not declawed).</param>
/// <param name="photo">Optional photo.</param>
/// <param name="microchip">Optional microchip.</param>
/// <param name="createdByUserId">The user ID of the creator.</param>
/// <param name="createdAt">The creation date and time.</param>
/// <param name="modifiedByUserId">The user ID of the modifier.</param>
/// <param name="modifiedAt">The modification date and time.</param>
public sealed class Cat(
    string name,
    Guid primaryBreedId,
    Guid colorId,
    Gender gender,
    DateTimeOffset birthDate,
    bool isAnUnclawnedCat,
    Photo? photo,
    Microchip? microchip,
    Guid createdByUserId,
    DateTimeOffset createdAt,
    Guid? modifiedByUserId = null,
    DateTimeOffset? modifiedAt = null) : Animal(name, SpeciesType.Cat,primaryBreedId, colorId, gender, birthDate, photo, microchip, createdByUserId, createdAt, modifiedByUserId, modifiedAt)
{
    /// <summary>
    /// Gets a value indicating whether this cat is unclawned (has not been declawed).
    /// </summary>
    public bool IsAnUnclawnedCat { get; private set; } = isAnUnclawnedCat;
}
