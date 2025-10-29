// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Mappers;
using Beagl.Application.AnimalManagement.Services;
using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.AnimalManagement.Repositories;

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

        Cat newCat = createCatDto.ToDomain();

        Guid catId = await catRepository.CreateAsync(newCat);
        return catId;
    }
}
