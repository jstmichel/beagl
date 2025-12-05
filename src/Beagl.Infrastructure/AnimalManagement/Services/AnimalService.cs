// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.AnimalManagement.Mappers;
using Beagl.Infrastructure.Core.Helpers;
using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.Core.Exceptions;
using Beagl.Infrastructure.AnimalManagement.DTOs;

namespace Beagl.Infrastructure.AnimalManagement.Services;

/// <summary>
/// Implementation of animal-related operations.
/// </summary>
public sealed class AnimalService(
    ApplicationDbContext dbContext) : IAnimalService
{
    /// <inheritdoc />
    public async Task<Result<Guid>> CreateCatAsync(CreateCatDto createCatDto)
    {
        ArgumentNullException.ThrowIfNull(createCatDto);

        try
        {
            Cat newCat = createCatDto.ToDomain();
            dbContext.Cats.Add(newCat);
            await dbContext.SaveChangesAsync();
            return ApplicationResult.Ok(newCat.Id);
        }
        catch (DomainException ex)
        {
            return ApplicationResult.Fail<Guid>(ex.ErrorCode, ex.Message);
        }
    }

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
