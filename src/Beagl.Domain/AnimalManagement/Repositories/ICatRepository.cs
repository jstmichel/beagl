// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Threading.Tasks;
using Beagl.Domain.AnimalManagement.Entities;

namespace Beagl.Domain.AnimalManagement.Repositories;

/// <summary>
/// Repository interface for managing Cat entities.
/// </summary>
public interface ICatRepository
{
    /// <summary>
    /// Asynchronously creates a new Cat entity in the data store.
    /// </summary>
    /// <param name="cat">The Cat entity to create.</param>
    /// <returns>The unique identifier (Guid) of the created Cat.</returns>
    public Task<Guid> CreateAsync(Cat cat);
}
