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
/// Implementation of cat-related operations.
/// </summary>
public sealed class CatService(
    ICatRepository catRepository) : ICatService
{
    /// <inheritdoc />
    public async Task<Result<Guid>> CreateCatAsync(CreateCatDto createCatDto)
    {
        ArgumentNullException.ThrowIfNull(createCatDto);

        try
        {
            Cat newCat = createCatDto.ToDomain();
            Guid catId = await catRepository.CreateAsync(newCat);
            return ApplicationResult.Ok(catId);
        }
        catch (DomainException ex)
        {
            return ApplicationResult.Fail<Guid>(ex.ErrorCode, ex.Message);
        }
    }
}
