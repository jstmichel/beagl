// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Services;
using Beagl.Domain.AnimalManagement.Entities;
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

        Dog newDog = new()
        {
            Id = Guid.NewGuid(),
            SpeciesType = SpeciesType.Dog,
            Name = createDogDto.Name,
            PrimaryBreedId = createDogDto.BreedPrimaryId,
            ColorId = createDogDto.ColorId,
            DistinctiveDescription = createDogDto.Description ?? string.Empty,
            Gender = GenderHelper.FromInt(createDogDto.Gender),
            DateOfBirth = createDogDto.BirthDate.ToUniversalTime(), //FIXME:Find a solution for the repository layer to transform to UTC
            Photo = Photo.From(createDogDto.PhotoBase64),
            Microchip = Microchip.From(createDogDto.MicrochipNumber),
            Weight = Weight.From(createDogDto.Weight, WeightUnitHelper.FromInt(createDogDto.WeightUnit)),
            Created = Audit.From(Guid.Empty, DateTimeOffset.UtcNow.ToUniversalTime()), //TODO: Replace with actual user ID
            Modified = null,
        };

        Guid dogId = await dogRepository.CreateAsync(newDog);
        return dogId;
    }
}
