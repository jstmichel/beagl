// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Mappers;
using Beagl.Application.AnimalManagement.Services;
using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.AnimalManagement.Repositories;

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

        Dog newDog = createDogDto.ToDomain();

        Guid dogId = await dogRepository.CreateAsync(newDog);
        return dogId;
    }
}
