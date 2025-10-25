// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Threading.Tasks;
using Beagl.Domain.AnimalManagement.Entities;

namespace Beagl.Domain.AnimalManagement.Repositories;

/// <summary>
/// Repository interface for managing Dog entities.
/// </summary>
public interface IDogRepository
{
    /// <summary>
    /// Asynchronously creates a new Dog entity in the data store.
    /// </summary>
    /// <param name="dog">The Dog entity to create.</param>
    /// <returns>The unique identifier (Guid) of the created Dog.</returns>
    public Task<Guid> CreateAsync(Dog dog);
}
