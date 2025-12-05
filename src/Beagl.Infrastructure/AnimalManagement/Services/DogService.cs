// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.Core.Helpers;
using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.Core.Exceptions;
using Beagl.Infrastructure.AnimalManagement.DTOs;
using Beagl.Infrastructure.AnimalManagement.Mappers;

namespace Beagl.Infrastructure.AnimalManagement.Services;

/// <summary>
/// Implementation of dog-related operations.
/// </summary>
public sealed class DogService(
    ApplicationDbContext dbContext) : IDogService
{
    /// <inheritdoc />
    public async Task<Result<Guid>> CreateDogAsync(CreateDogDto createDogDto)
    {
        ArgumentNullException.ThrowIfNull(createDogDto);

        try
        {
            Dog newDog = createDogDto.ToDomain();
            dbContext.Dogs.Add(newDog);
            await dbContext.SaveChangesAsync();
            return ApplicationResult.Ok(newDog.Id);
        }
        catch (DomainException ex)
        {
            return ApplicationResult.Fail<Guid>(ex.ErrorCode, ex.Message);
        }
    }
}
