// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Services;
using Beagl.Domain.AnimalManagement.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Beagl.Infrastructure.AnimalManagement.Services;

/// <summary>
/// Service for querying available breeds for animals.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="BreedQueryService"/> class.
/// </remarks>
/// <param name="dbContext">The database context.</param>
public sealed class BreedQueryService(ApplicationDbContext dbContext) : IBreedQueryService
{
    /// <inheritdoc/>
    public async Task<IList<BreedDto>> GetAllBySpeciesAsync(SpeciesType species)
    {
        return await dbContext.Breeds
            .Where(b => b.SpeciesType == species)
            .Select(b => new BreedDto
            {
                Id = b.Id,
                Name = b.Name
            })
            .ToListAsync();
    }
}
