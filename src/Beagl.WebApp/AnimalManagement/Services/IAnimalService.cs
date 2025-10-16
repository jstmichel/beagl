// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Core.Interfaces;
using Beagl.Infrastructure.AnimalManagement.DTOs;

namespace Beagl.WebApp.AnimalManagement.Services;

/// <summary>
/// Service layer for managing Animal aggregates.
/// </summary>
internal interface IAnimalService : IPagedService<AnimalDto, AnimalPagedFilterDto>
{
    /// <summary>
    /// Creates a new animal.
    /// </summary>
    /// <param name="animalDto">The Animal DTO to create.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task CreateAsync(AnimalDto animalDto);

    /// <summary>
    /// Updates an existing animal.
    /// </summary>
    /// <param name="animalDto">The Animal DTO to update.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task UpdateAsync(AnimalDto animalDto);

    /// <summary>
    /// Gets an animal by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the animal.</param>
    /// <returns>The Animal DTO, or null if not found.</returns>
    public Task<AnimalDto?> GetByIdAsync(Guid id);

    /// <summary>
    /// Removes an animal.
    /// </summary>
    /// <param name="id">The unique identifier of the animal to remove.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task RemoveAsync(Guid id);
}
