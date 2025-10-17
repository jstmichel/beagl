// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.AnimalManagement;
using Beagl.Infrastructure.AnimalManagement.Models;

namespace Beagl.Infrastructure.AnimalManagement.Extensions;

/// <summary>
/// Extension methods for mapping Animal aggregate to persistence model.
/// </summary>
public static class AnimalMappingExtensions
{
    /// <summary>
    /// Maps an <see cref="Animal"/> aggregate to an <see cref="AnimalEntity"/> persistence model.
    /// </summary>
    /// <param name="animal">The domain aggregate to map.</param>
    /// <returns>The mapped persistence model.</returns>
    public static AnimalEntity ToEntity(this Animal animal)
    {
        ArgumentNullException.ThrowIfNull(animal);
        animal.Created.At = animal.Created.At.ToUniversalTime();
        return new AnimalEntity
        {
            Id = animal.Id,
            Name = animal.Name,
            Species = animal.Species,
            Breed = animal.Breed,
            Color = animal.Color,
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
            Modified = animal.Modified,
        };
    }
}
