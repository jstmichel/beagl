// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Domain.AnimalManagement;
using Beagl.Infrastructure.AnimalManagement.Models;

namespace Beagl.Infrastructure.AnimalManagement.Extensions;

/// <summary>
/// Extension methods for mapping Animal aggregate to persistence model.
/// </summary>
public static class AnimalMappingExtensions
{
    /// <summary>
    /// Maps an <see cref="Animal"/> aggregate to an <see cref="AnimalModel"/> persistence model.
    /// </summary>
    /// <param name="animal">The domain aggregate to map.</param>
    /// <returns>The mapped persistence model.</returns>
    public static AnimalModel ToEntity(this Animal animal)
    {
        ArgumentNullException.ThrowIfNull(animal);
        animal.Created.At = animal.Created.At.ToUniversalTime();
        AnimalModel entity = new()
        {
            Id = animal.Id,
            Name = animal.Name,
            SpeciesId = animal.SpeciesId,
            PrimaryBreedId = animal.PrimaryBreedId,
            SecondaryBreedId = animal.SecondaryBreedId,
            ColorId = animal.ColorId,
            DistinctiveDescription = animal.DistinctiveDescription,
            Gender = animal.Gender,
            DateOfBirth = animal.DateOfBirth.ToUniversalTime(),
            Photo = animal.Photo,
            Microchip = animal.Microchip,
            DangerousDog = animal.DangerousDog,
            IsAnAssistanceDog = animal.IsAnAssistanceDog,
            IsAnUnclawnedCat = animal.IsAnUnclawnedCat,
            OriginCityInfo = animal.OriginCityInfo,
            Created = animal.Created,
        };

        if (animal.Modified != null)
        {
            entity.Modified = animal.Modified;
        }

        return entity;
    }

    /// <summary>
    /// Maps an <see cref="AnimalModel"/> persistence model to an <see cref="Animal"/> aggregate.
    /// </summary>
    /// <param name="entity">The persistence model to map.</param>
    /// <returns>The mapped domain aggregate.</returns>
    public static Animal ToDomain(this AnimalModel entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return Animal.Rehydrate(
            id: entity.Id,
            name: entity.Name,
            speciesId: entity.SpeciesId,
            primaryBreedId: entity.PrimaryBreedId,
            secondaryBreedId: entity.SecondaryBreedId,
            colorId: entity.ColorId,
            distinctiveDescription: entity.DistinctiveDescription!,
            gender: entity.Gender,
            dateOfBirth: entity.DateOfBirth.ToLocalTime(),
            photo: entity.Photo,
            microchip: entity.Microchip,
            dangerousDog: entity.DangerousDog,
            isAnAssistanceDog: entity.IsAnAssistanceDog,
            isAnUnclawnedCat: entity.IsAnUnclawnedCat,
            originCityInfo: entity.OriginCityInfo,
            createdByUserId: entity.Created.UserId,
            createdAt: entity.Created.At,
            modifiedByUserId: entity.Modified?.UserId,
            modifiedAt: entity.Modified?.At
        );
    }

    /// <summary>
    /// Maps an <see cref="AnimalModel"/> persistence model to an <see cref="Animal"/> aggregate.
    /// </summary>
    /// <param name="entity">The persistence model to map.</param>
    /// <returns>The mapped domain aggregate.</returns>
    public static AnimalListDto ToListDto(this AnimalModel entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new AnimalListDto
        {
            Id = entity.Id,
            Name = entity.Name,
            // SpeciesId = entity.SpeciesId,
            // PrimaryBreedId = entity.PrimaryBreedId,
            // SecondaryBreedId = entity.SecondaryBreedId,
            // ColorId = entity.ColorId,
            Gender = entity.Gender.Value,
            BirthDate = entity.DateOfBirth.ToLocalTime(),
            MicrochipNumber = entity.Microchip?.Value,
        };
    }
}
