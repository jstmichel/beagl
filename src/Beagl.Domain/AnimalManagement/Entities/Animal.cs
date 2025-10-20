// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.AnimalManagement.ValueObjects;
using Beagl.Domain.Core;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Domain.AnimalManagement.Entities;

/// <summary>
/// Base aggregate root for all animals.
/// </summary>
/// <remarks>
/// Protected constructor for derived classes.
/// </remarks>
/// <remarks>
/// Protected constructor for derived animal classes.
/// </remarks>
/// <param name="name">The animal's name.</param>
/// <param name="primaryBreedId">Primary breed identifier.</param>
/// <param name="colorId">Color identifier.</param>
/// <param name="gender">Gender of the animal.</param>
/// <param name="birthDate">Birth date of the animal.</param>
/// <param name="photo">Optional photo.</param>
/// <param name="microchip">Optional microchip.</param>
/// <param name="createdByUserId">Identifier of the user who created the animal.</param>
/// <param name="createdAt">Date and time when the animal was created.</param>
/// <param name="modifiedByUserId">Optional identifier of the user who last modified the animal.</param>
/// <param name="modifiedAt">Optional date and time when the animal was last modified.</param>
/// <param name="speciesType">Species type of the animal.</param>
public abstract class Animal(string name,
    SpeciesType speciesType,
    Guid primaryBreedId,
    Guid colorId,
    Gender gender,
    DateTimeOffset birthDate,
    Photo? photo,
    Microchip? microchip,
    Guid createdByUserId,
    DateTimeOffset createdAt,
    Guid? modifiedByUserId = null,
    DateTimeOffset? modifiedAt = null)
        : AuditedAggregateRoot<Guid>(createdByUserId, createdAt, modifiedByUserId.GetValueOrDefault(), modifiedAt)
{

    /// <summary>
    /// Gets the name of the animal.
    /// </summary>
    public string Name { get; protected set; } = name;

    /// <summary>
    /// Gets the primary breed identifier.
    /// </summary>
    public Guid PrimaryBreedId { get; protected set; } = primaryBreedId;

    /// <summary>
    /// Gets the color identifier.
    /// </summary>
    public Guid ColorId { get; protected set; } = colorId;

    /// <summary>
    /// Gets the gender of the animal.
    /// </summary>
    public Gender Gender { get; protected set; } = gender;

    /// <summary>
    /// Gets the birth date of the animal.
    /// </summary>
    public DateTimeOffset BirthDate { get; protected set; } = birthDate;

    /// <summary>
    /// Gets the photo of the animal as a value object.
    /// </summary>
    public Photo? Photo { get; protected set; } = photo;

    /// <summary>
    /// Gets the microchip of the animal as a value object.
    /// </summary>
    public Microchip? Microchip { get; protected set; } = microchip;

    /// <summary>
    /// Gets the species type of the animal.
    /// </summary>
    public SpeciesType SpeciesType { get; protected set; } = speciesType;
}
