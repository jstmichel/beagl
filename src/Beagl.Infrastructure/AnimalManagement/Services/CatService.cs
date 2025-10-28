// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Services;
using Beagl.Application.Core.Helpers;
using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.AnimalManagement.Enums;
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
            SpeciesType.Cat,
            createCatDto.Name,
            createCatDto.BreedPrimaryId,
            null,
            createCatDto.ColorId,
            null,
            createCatDto.Description ?? string.Empty,
            EnumHelper.FromInt<Gender>(createCatDto.Gender),
            createCatDto.BirthDate.ToUniversalTime(), //FIXME:Find a solution for the repository layer to transform to UTC
            Photo.From(createCatDto.PhotoBase64),
            Microchip.From(createCatDto.MicrochipNumber),
            Weight.From(createCatDto.Weight, EnumHelper.FromInt<WeightUnit>(createCatDto.WeightUnit)),
            Audit.From(Guid.Empty, DateTimeOffset.UtcNow.ToUniversalTime()),  //TODO: Replace with actual user ID
            createCatDto.IsAnUnclawnedCat
        );

        Guid catId = await catRepository.CreateAsync(newCat);
        return catId;
    }
}
