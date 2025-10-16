// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.AnimalManagement;
using Beagl.Domain.AnimalManagement.Repositories;
using Beagl.Domain.Core.Interfaces;
using Beagl.Infrastructure.AnimalManagement.DTOs;

namespace Beagl.WebApp.AnimalManagement.Services;

/// <summary>
/// Service layer implementation for managing Animal aggregates.
/// </summary>
internal sealed class AnimalService(
    IAnimalRepository animalRepository,
    IEntityMapper<Animal, AnimalDto> animalMapper) : IAnimalService
{
    public async Task CreateAsync(AnimalDto animalDto)
    {
        Animal animal = animalMapper.CreateFromDto(animalDto);
        await animalRepository.AddAsync(animal);
    }

    public async Task UpdateAsync(AnimalDto animalDto)
    {
        Animal animal = animalMapper.CreateFromDto(animalDto);
        await animalRepository.UpdateAsync(animal);
    }

    public async Task<AnimalDto?> GetByIdAsync(Guid id)
    {
        Animal? animal = await animalRepository.GetByIdAsync(id);
        return animal is null ? null : animalMapper.ToDto(animal);
    }

    public async Task RemoveAsync(Guid id)
    {
        Animal? animal = await animalRepository.GetByIdAsync(id);
        if (animal is not null)
        {
            await animalRepository.RemoveAsync(animal);
        }
    }

    /// <inheritdoc/>
    public async Task<(IList<AnimalDto> Items, int TotalCount)> GetPagedAsync(
        AnimalPagedFilterDto filter)
    {
        (IList<Animal>? items, int totalCount) = await animalRepository.GetPagedAsync(filter);
        List<AnimalDto> dtos = [.. items.Select(animalMapper.ToDto)];
        return (dtos, totalCount);
    }
}
