// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Services;
using Microsoft.EntityFrameworkCore;

namespace Beagl.Infrastructure.AnimalManagement.Services;

/// <summary>
/// Service for querying available species for animals.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="SpeciesQueryService"/> class.
/// </remarks>
/// <param name="dbContext">The database context.</param>
public sealed class SpeciesQueryService(ApplicationDbContext dbContext) : ISpeciesQueryService
{
    /// <inheritdoc/>
    public async Task<IList<SpeciesDto>> GetAllAsync()
    {
        return await dbContext.Species
            .Where(s => s.IsActive)
            .Select(s => new SpeciesDto
            {
                Id = s.Id,
                Name = s.Name
            })
            .ToListAsync();
    }
}
