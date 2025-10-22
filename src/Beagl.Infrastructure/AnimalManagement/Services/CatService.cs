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

        Cat newCat = new(
            name: createCatDto.Name,
            primaryBreedId: createCatDto.BreedPrimaryId,
            colorId: createCatDto.ColorId,
            distinctiveDescription: createCatDto.Description ?? string.Empty,
            gender: GenderHelper.FromInt(createCatDto.Gender),
            birthDate: createCatDto.BirthDate,
            isAnUnclawnedCat: createCatDto.IsAnUnclawnedCat,
            photo: Photo.From(createCatDto.PhotoBase64),
            microchip: Microchip.From(createCatDto.MicrochipNumber),
            weight: Weight.From(createCatDto.Weight, WeightUnitHelper.FromInt(createCatDto.WeightUnit)),
            createdByUserId: Guid.Empty, //TODO: Replace with actual user ID
            createdAt: DateTimeOffset.UtcNow.ToUniversalTime()
        );

        Guid catId = await catRepository.CreateAsync(newCat);
        return catId;
    }
}
