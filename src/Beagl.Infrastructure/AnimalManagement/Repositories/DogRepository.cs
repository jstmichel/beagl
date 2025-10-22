// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.AnimalManagement.Repositories;

namespace Beagl.Infrastructure.AnimalManagement.Repositories;

/// <summary>
/// Repository implementation for managing Dog entities.
/// </summary>
internal sealed class DogRepository(
    ApplicationDbContext dbContext) : IDogRepository
{
    /// <summary>
    /// Asynchronously creates a new Dog entity in the data store.
    /// </summary>
    /// <param name="dog">The Dog entity to create.</param>
    /// <returns>The unique identifier (Guid) of the created Dog.</returns>
    public async Task<Guid> CreateAsync(Dog dog)
    {
        dbContext.Dogs.Add(dog);
        await dbContext.SaveChangesAsync();
        return dog.Id;
    }
}
