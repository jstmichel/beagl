// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.AnimalManagement.Enums;
using Beagl.Domain.AnimalManagement.ValueObjects;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Domain.AnimalManagement.Entities;

/// <summary>
/// Persistence model for cat-specific data (TPT).
/// </summary>
public sealed class Cat : Animal
{
    /// <summary>
    /// Gets or sets whether the cat is unclawned.
    /// </summary>
    public bool IsAnUnclawnedCat { get; private set; }


    /// <summary>
    /// Private parameterless constructor for EF Core.
    /// </summary>
    private Cat() { }

    /// <summary>
    /// Public constructor to create a new Cat aggregate with all fields.
    /// </summary>
    public Cat(
        SpeciesType speciesType,
        string name,
        Guid primaryBreedId,
        Breed? primaryBreed,
        Guid colorId,
        Color? color,
        string? distinctiveDescription,
        Gender gender,
        DateTimeOffset dateOfBirth,
        Photo? photo,
        Microchip? microchip,
        Weight weight,
        Audit<Guid> created,
        bool isAnUnclawnedCat)
        : base(speciesType, name, primaryBreedId, primaryBreed, colorId, color, distinctiveDescription, gender, dateOfBirth, photo, microchip, weight, created)
    {
        IsAnUnclawnedCat = isAnUnclawnedCat;
    }
}
