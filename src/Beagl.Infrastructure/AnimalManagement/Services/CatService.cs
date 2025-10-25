// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Services;
using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.AnimalManagement.Repositories;
using Beagl.Domain.AnimalManagement.ValueObjects;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Infrastructure.AnimalManagement.Services;

/// <summary>
/// Implementation of cat-related operations.
/// </summary>
public sealed class CatService(
    ICatRepository catRepository) : ICatService
{
    /// <inheritdoc />
    public async Task<Guid> CreateCatAsync(CreateCatDto createCatDto)
    {
        ArgumentNullException.ThrowIfNull(createCatDto);

        Cat newCat = new()
        {
            Id = Guid.NewGuid(),
            SpeciesType = SpeciesType.Cat,
            Name = createCatDto.Name,
            PrimaryBreedId = createCatDto.BreedPrimaryId,
            ColorId = createCatDto.ColorId,
            DistinctiveDescription = createCatDto.Description ?? string.Empty,
            Gender = GenderHelper.FromInt(createCatDto.Gender),
            DateOfBirth = createCatDto.BirthDate.ToUniversalTime(), //FIXME:Find a solution for the repository layer to transform to UTC
            IsAnUnclawnedCat = createCatDto.IsAnUnclawnedCat,
            Photo = Photo.From(createCatDto.PhotoBase64),
            Microchip = Microchip.From(createCatDto.MicrochipNumber),
            Weight = Weight.From(createCatDto.Weight, WeightUnitHelper.FromInt(createCatDto.WeightUnit)),
            Created = Audit.From(Guid.Empty, DateTimeOffset.UtcNow.ToUniversalTime()), //TODO: Replace with actual user ID
            Modified = null,
        };

        Guid catId = await catRepository.CreateAsync(newCat);
        return catId;
    }
}
