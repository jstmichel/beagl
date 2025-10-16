// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Collections.Generic;
using Beagl.Domain.AnimalManagement.Entities;
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
public class Animal(
        string name,
        string species,
        Breed breed,
        string color,
        Gender gender,
        DateTime dateOfBirth,
        Guid userId,
        DateTime createdAt) : AuditedAggregateRoot(userId, createdAt)
{
    /// <summary>
    /// Private parameterless constructor for ORM and serialization purposes.
    /// </summary>
    private Animal() :
        this(default!, default!, default!, default!, default!, default!, default!, default!)
    { }

    /// <summary>
    /// Gets or sets the name of the animal.
    /// </summary>
    public string Name { get; private set; } = name;

    /// <summary>
    /// Gets or sets the species of the animal.
    /// </summary>
    public string Species { get; private set; } = species;

    /// <summary>
    /// Gets or sets the breed information for the animal.
    /// </summary>
    public Breed Breed { get; private set; } = breed;

    /// <summary>
    /// Gets or sets the color of the animal.
    /// </summary>
    public string Color { get; private set; } = color;

    /// <summary>
    /// Gets or sets the description of the animal.
    /// </summary>
    public string? DistinctiveDescription { get; private set; }

    /// <summary>
    /// Gets or sets the gender of the animal.
    /// </summary>
    public Gender Gender { get; private set; } = gender;

    /// <summary>
    /// Gets or sets the date of birth of the animal.
    /// </summary>
    public DateTime DateOfBirth { get; private set; } = dateOfBirth;

    /// <summary>
    /// Gets or sets the animal's photo as a base64-encoded PNG image.
    /// </summary>
    public Photo? Photo { get; private set; }

    /// <summary>
    /// Gets or sets the microchip identifier of the animal, if any.
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

    /// <summary>
    /// Gets or sets the size of the animal (e.g., Small, Medium, Large).
    /// </summary>
    public ICollection<HealthRecord> HealthRecords { get; init; } = [];

    /// <summary>
    /// Gets the collection of medal assignment records for the animal.
    /// </summary>
    public ICollection<MedalRecord> MedalRecords { get; init; } = [];

    /// <summary>
    /// Renames the animal, enforcing non-empty name invariant.
    /// </summary>
    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Name cannot be empty.");
        Name = newName;
    }

    /// <summary>
    /// Changes the species of the animal, enforcing non-empty species invariant.
    /// </summary>
    public void ChangeSpecies(string newSpecies)
    {
        if (string.IsNullOrWhiteSpace(newSpecies))
            throw new ArgumentException("Species cannot be empty.");
        Species = newSpecies;
    }

    /// <summary>
    /// Changes the breed of the animal.
    /// </summary>
    public void ChangeBreed(Breed newBreed)
    {
        Breed = newBreed ?? throw new ArgumentNullException(nameof(newBreed));
    }

    /// <summary>
    /// Changes the color of the animal, enforcing non-empty color invariant.
    /// </summary>
    public void ChangeColor(string newColor)
    {
        if (string.IsNullOrWhiteSpace(newColor))
            throw new ArgumentException("Color cannot be empty.");
        Color = newColor;
    }

    /// <summary>
    /// Sets the distinctive description of the animal.
    /// </summary>
    public void SetDistinctiveDescription(string? description)
    {
        DistinctiveDescription = description;
    }

    /// <summary>
    /// Changes the gender of the animal.
    /// </summary>
    public void ChangeGender(Gender newGender)
    {
        Gender = newGender;
    }

    /// <summary>
    /// Changes the date of birth of the animal, enforcing that it cannot be in the future.
    /// </summary>
    public void ChangeDateOfBirth(DateTime newDate)
    {
        if (newDate > DateTime.UtcNow)
            throw new ArgumentException("Date of birth cannot be in the future.");
        DateOfBirth = newDate;
    }

    /// <summary>
    /// Sets the photo of the animal.
    /// </summary>
    public void SetPhoto(Photo? photo)
    {
        Photo = photo;
    }

    /// <summary>
    /// Sets the microchip information for the animal.
    /// </summary>
    public void SetMicrochip(Microchip? microchip)
    {
        Microchip = microchip;
    }

    /// <summary>
    /// Sets the dangerous dog status and related information.
    /// </summary>
    public void SetDangerousDog(DangerousDog? dangerousDog)
    {
        DangerousDog = dangerousDog;
    }

    /// <summary>
    /// Sets whether the animal is an assistance dog.
    /// </summary>
    public void SetAssistanceDog(bool isAssistanceDog)
    {
        IsAnAssistanceDog = isAssistanceDog;
    }

    /// <summary>
    /// Sets whether the animal is an unclawned cat.
    /// </summary>
    public void SetUnclawnedCat(bool isUnclawnedCat)
    {
        IsAnUnclawnedCat = isUnclawnedCat;
    }

    /// <summary>
    /// Sets the origin city information for the animal.
    /// </summary>
    public void SetOriginCityInfo(OriginCityInfo? originCityInfo)
    {
        OriginCityInfo = originCityInfo;
    }

    /// <summary>
    /// Adds a health record to the animal's health records collection.
    /// </summary>
    public void AddHealthRecord(HealthRecord record)
    {
        ArgumentNullException.ThrowIfNull(record);
        HealthRecords.Add(record);
    }

    /// <summary>
    /// Removes a health record from the animal's health records collection.
    /// </summary>
    public void RemoveHealthRecord(HealthRecord record)
    {
        ArgumentNullException.ThrowIfNull(record);
        HealthRecords.Remove(record);
    }

    /// <summary>
    /// Adds a medal record to the animal's medal records collection.
    /// </summary>
    public void AddMedalRecord(MedalRecord record)
    {
        ArgumentNullException.ThrowIfNull(record);
        MedalRecords.Add(record);
    }

    /// <summary>
    /// Removes a medal record from the animal's medal records collection.
    /// </summary>
    public void RemoveMedalRecord(MedalRecord record)
    {
        ArgumentNullException.ThrowIfNull(record);
        MedalRecords.Remove(record);
    }
}
