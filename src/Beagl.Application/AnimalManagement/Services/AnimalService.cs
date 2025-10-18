// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.Core.Interfaces;
using Beagl.Domain.AnimalManagement;
using Beagl.Domain.AnimalManagement.Repositories;
using Beagl.Domain.Core.Interfaces;

namespace Beagl.Application.AnimalManagement.Services;

/// <summary>
/// Service layer implementation for managing Animal aggregates.
/// </summary>
public sealed class AnimalService(
    IAnimalRepository animalRepository,
    IEntityMapper<Animal, AnimalDto> animalMapper,
    ICurrentUserService currentUserService) : IAnimalService
{
    /// <summary>
    /// Creates a new animal record.
    /// </summary>
    /// <param name="animalDto">The animal data transfer object.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task CreateAsync(AnimalDto animalDto)
    {
        ArgumentNullException.ThrowIfNull(animalDto);

        animalDto.CreatedByUserId = currentUserService.UserId;
        animalDto.CreatedAt = DateTime.UtcNow;
        Animal animal = animalMapper.CreateFromDto(animalDto);
        await animalRepository.AddAsync(animal);
    }

    /// <summary>
    /// Updates an existing animal record.
    /// </summary>
    /// <param name="animalDto">The animal data transfer object with updated information.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateAsync(AnimalDto animalDto)
    {
        Animal animal = animalMapper.CreateFromDto(animalDto);
        await animalRepository.UpdateAsync(animal);
    }

    /// <summary>
    /// Retrieves an animal by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the animal.</param>
    /// <returns>The animal data transfer object if found; otherwise, null.</returns>
    public async Task<AnimalDto?> GetByIdAsync(Guid id)
    {
        Animal? animal = await animalRepository.GetByIdAsync(id);
        return animal is null ? null : animalMapper.ToDto(animal);
    }

    /// <summary>
    /// Removes an animal record by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the animal to remove.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task RemoveAsync(Guid id)
    {
        Animal? animal = await animalRepository.GetByIdAsync(id);
        if (animal is not null)
        {
            await animalRepository.RemoveAsync(animal);
        }
    }
}
