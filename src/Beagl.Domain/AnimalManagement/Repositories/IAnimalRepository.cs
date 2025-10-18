// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Threading.Tasks;

namespace Beagl.Domain.AnimalManagement.Repositories;

/// <summary>
/// Repository interface for managing Animal aggregate roots.
/// </summary>
public interface IAnimalRepository
{
    /// <summary>
    /// Adds a new Animal aggregate to the data store.
    /// </summary>
    /// <param name="animal">The Animal aggregate to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task AddAsync(Animal animal);

    /// <summary>
    /// Updates an existing Animal aggregate in the data store.
    /// </summary>
    /// <param name="animal">The Animal aggregate to update.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task UpdateAsync(Animal animal);

    /// <summary>
    /// Gets an Animal aggregate by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the Animal.</param>
    /// <returns>The Animal aggregate, or null if not found.</returns>
    public Task<Animal?> GetByIdAsync(Guid id);

    /// <summary>
    /// Removes an Animal aggregate from the data store.
    /// </summary>
    /// <param name="animal">The Animal aggregate to remove.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task RemoveAsync(Animal animal);
}
