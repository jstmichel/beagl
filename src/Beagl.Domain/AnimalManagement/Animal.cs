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
        DateTime dateOfBirth,
        Guid userId,
        DateTime createdAt,
        Photo? photo,
        Microchip? microchip,
        DangerousDog? dangerousDog,
        bool isAnAssistanceDog,
        bool isAnUnclawnedCat,
        OriginCityInfo? originCityInfo)
        : base(userId, createdAt)
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
        DateTime dateOfBirth,
        Guid userId,
        DateTime createdAt,
        Photo? photo = null,
        Microchip? microchip = null,
        DangerousDog? dangerousDog = null,
        bool isAnAssistanceDog = false,
        bool isAnUnclawnedCat = false,
        OriginCityInfo? originCityInfo = null)
    {
        // Add validation logic as needed
        return new Animal(name, species, breed, color, gender, dateOfBirth, userId, createdAt, photo, microchip, dangerousDog, isAnAssistanceDog, isAnUnclawnedCat, originCityInfo);
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
    public DateTime DateOfBirth { get; private set; }

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
}
