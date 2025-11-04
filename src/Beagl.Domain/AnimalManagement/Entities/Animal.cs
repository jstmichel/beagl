// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.AnimalManagement.Enums;
using Beagl.Domain.AnimalManagement.ValueObjects;
using Beagl.Domain.CitizenManagement.Entities;
using Beagl.Domain.Core;
using Beagl.Domain.Core.ValueObjects;


namespace Beagl.Domain.AnimalManagement.Entities;

/// <summary>
/// Persistence model for Animal aggregate, using value objects.
/// </summary>
public class Animal : AuditedAggregateRoot
{
    /// <summary>
    /// Gets or sets the optional foreign key to the owning citizen.
    /// </summary>
    public Guid? CitizenId { get; private set; }

    /// <summary>
    /// Gets or sets the navigation property to the owning citizen.
    /// </summary>
    public Citizen? Citizen { get; private set; }

    /// <summary>
    /// Gets or sets the species type (discriminator for TPT).
    /// </summary>
    public SpeciesType SpeciesType { get; private set; } = SpeciesType.Unknown;

    /// <summary>
    /// Gets or sets the name of the animal.
    /// </summary>
    public string Name { get; private set; } = default!;

    /// <summary>
    /// Gets or sets the foreign key for the primary breed of the animal.
    /// </summary>
    public Guid PrimaryBreedId { get; private set; }

    /// <summary>
    /// Gets or sets the related primary breed entity.
    /// </summary>
    public Breed? PrimaryBreed { get; private set; }

    /// <summary>
    /// Gets or sets the foreign key for the color of the animal.
    /// </summary>
    public Guid ColorId { get; private set; }

    /// <summary>
    /// Gets or sets the related color entity.
    /// </summary>
    public Color? Color { get; private set; }

    /// <summary>
    /// Gets or sets the distinctive description of the animal.
    /// </summary>
    public string? DistinctiveDescription { get; private set; }

    /// <summary>
    /// Gets or sets the gender of the animal.
    /// </summary>
    public Gender Gender { get; private set; } = Gender.Unknown;

    /// <summary>
    /// Gets or sets the date of birth of the animal.
    /// </summary>
    public DateTimeOffset DateOfBirth { get; private set; }

    /// <summary>
    /// Gets or sets the photo of the animal as a value object.
    /// </summary>
    public Photo? Photo { get; private set; }

    /// <summary>
    /// Gets or sets the microchip information for the animal.
    /// </summary>
    public Microchip? Microchip { get; private set; }

    /// <summary>
    /// Gets or sets the weight of the animal as a value object.
    /// </summary>
    public Weight Weight { get; private set; } = default!;

    /// <summary>
    /// Gets or sets the medal awarded to the animal as a value object.
    /// </summary>
    public Medal? Medal { get; private set; }

    /// <summary>
    /// Gets or sets whether the animal is sterilized.
    /// </summary>
    public bool IsSterilized { get; private set; }

    /// <summary>
    /// Gets or sets the rabies vaccination information for the animal.
    /// </summary>
    public RabiesVaccination? RabiesVaccination { get; private set; }


    /// <summary>
    /// Private parameterless constructor for EF Core.
    /// </summary>
    protected Animal() { }

    /// <summary>
    /// Public constructor to create a new Animal aggregate with all fields.
    /// </summary>
    /// <param name="speciesType">The species type.</param>
    /// <param name="name">The name of the animal.</param>
    /// <param name="primaryBreedId">The primary breed ID.</param>
    /// <param name="colorId">The color ID.</param>
    /// <param name="distinctiveDescription">The distinctive description.</param>
    /// <param name="gender">The gender.</param>
    /// <param name="dateOfBirth">The date of birth.</param>
    /// <param name="photo">The photo value object.</param>
    /// <param name="microchip">The microchip value object.</param>
    /// <param name="weight">The weight value object.</param>
    /// <param name="medal">The medal value object.</param>
    /// <param name="isSterilized">Indicates if the animal is sterilized.</param>
    /// <param name="rabiesVaccination">The rabies vaccination information.</param>
    /// <param name="created">The creation audit info.</param>
    /// <param name="citizenId">The optional citizen ID.</param>
    public Animal(
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
        Medal? medal,
        bool isSterilized,
        RabiesVaccination? rabiesVaccination,
        Audit<Guid> created,
        Guid? citizenId = null)
        : base(created)
    {
        Id = Guid.NewGuid();
        SpeciesType = speciesType;
        Name = name;
        PrimaryBreedId = primaryBreedId;
        PrimaryBreed = null;
        ColorId = colorId;
        Color = null;
        DistinctiveDescription = distinctiveDescription;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        Photo = photo;
        Microchip = microchip;
        Weight = weight;
        Medal = medal;
        IsSterilized = isSterilized;
        RabiesVaccination = rabiesVaccination;
        CitizenId = citizenId;
        Citizen = null;
    }
}
