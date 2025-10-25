// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.AnimalManagement.Repositories;

namespace Beagl.Infrastructure.AnimalManagement.Repositories;

/// <summary>
/// Repository implementation for managing Cat entities.
/// </summary>
internal sealed class CatRepository(
    ApplicationDbContext dbContext) : ICatRepository
{
    /// <summary>
    /// Asynchronously creates a new Cat entity in the data store.
    /// </summary>
    /// <param name="cat">The Cat entity to create.</param>
    /// <returns>The unique identifier (Guid) of the created Cat.</returns>
    public async Task<Guid> CreateAsync(Cat cat)
    {
        dbContext.Cats.Add(cat);
        await dbContext.SaveChangesAsync();
        return cat.Id;
    }
}
