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
/// Implementation of dog-related operations.
/// </summary>
public sealed class DogService(
    IDogRepository dogRepository) : IDogService
{
    /// <inheritdoc />
    public async Task<Guid> CreateDogAsync(CreateDogDto createDogDto)
    {
        ArgumentNullException.ThrowIfNull(createDogDto);

        Dog newDog = new(
            SpeciesType.Dog,
            createDogDto.Name,
            createDogDto.BreedPrimaryId,
            null,
            createDogDto.ColorId,
            null,
            createDogDto.Description ?? string.Empty,
            EnumHelper.FromInt<Gender>(createDogDto.Gender),
            createDogDto.BirthDate.ToUniversalTime(), //FIXME:Find a solution for the repository layer to transform to UTC
            Photo.From(createDogDto.PhotoBase64),
            Microchip.From(createDogDto.MicrochipNumber),
            Weight.From(createDogDto.Weight, EnumHelper.FromInt<WeightUnit>(createDogDto.WeightUnit)),
            Audit.From(Guid.Empty, DateTimeOffset.UtcNow.ToUniversalTime()), //TODO: Replace with actual user ID
            createDogDto.BreedSecondaryId,
            null, //TODO: Missing fields
            null, //TODO: Missing fields
            false, //TODO: Missing fields
            null //TODO: Missing fields
        );

        Guid dogId = await dogRepository.CreateAsync(newDog);
        return dogId;
    }
}
