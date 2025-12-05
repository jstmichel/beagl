// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Mappers;
using Beagl.Application.AnimalManagement.Services;
using Beagl.Application.Core.Helpers;
using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.AnimalManagement.Repositories;
using Beagl.Domain.Core.Exceptions;
using Beagl.Infrastructure.Core.Helpers;

namespace Beagl.Infrastructure.AnimalManagement.Services;

/// <summary>
/// Implementation of dog-related operations.
/// </summary>
public sealed class DogService(
    IDogRepository dogRepository) : IDogService
{
    /// <inheritdoc />
    public async Task<Result<Guid>> CreateDogAsync(CreateDogDto createDogDto)
    {
        ArgumentNullException.ThrowIfNull(createDogDto);

        try
        {
            Dog newDog = createDogDto.ToDomain();
            Guid dogId = await dogRepository.CreateAsync(newDog);
            return ApplicationResult.Ok(dogId);
        }
        catch (DomainException ex)
        {
            return ApplicationResult.Fail<Guid>(ex.ErrorCode, ex.Message);
        }
    }
}
