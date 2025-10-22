using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.AnimalManagement.ValueObjects;
using Beagl.Domain.Core.ValueObjects;
using Beagl.Infrastructure.AnimalManagement.Models;

namespace Beagl.Infrastructure.AnimalManagement.Mappers;

/// <summary>
/// Maps between Cat domain entities and CatModel persistence models.
/// </summary>
internal static class CatMapper
{
    /// <summary>
    /// Maps a Cat domain entity to a CatModel persistence model.
    /// </summary>
    /// <param name="cat">The Cat domain entity.</param>
    /// <returns>The CatModel persistence model.</returns>
    public static CatModel ToModel(Cat cat)
    {
        return new CatModel
        {
            Id = cat.Id,
            Name = cat.Name,
            PrimaryBreedId = cat.PrimaryBreedId,
            ColorId = cat.ColorId,
            Gender = cat.Gender,
            DateOfBirth = cat.BirthDate.ToUniversalTime(),
            IsAnUnclawnedCat = cat.IsAnUnclawnedCat,
            Photo = cat.Photo,
            Microchip = cat.Microchip,
            DistinctiveDescription = cat.DistinctiveDescription,
            Weight = cat.Weight,
            Created = cat.Created,
            Modified = cat.Modified,
            SpeciesType = SpeciesType.Cat
        };
    }
}
