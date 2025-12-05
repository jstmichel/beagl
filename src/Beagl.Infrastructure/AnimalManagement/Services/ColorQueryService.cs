// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.AnimalManagement.Enums;
using Beagl.Infrastructure.AnimalManagement.DTOs;
using Beagl.Infrastructure.AnimalManagement.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Beagl.Infrastructure.AnimalManagement.Services;

/// <summary>
/// Service for querying available colors for animals.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ColorQueryService"/> class.
/// </remarks>
/// <param name="dbContext">The database context.</param>
public sealed class ColorQueryService(ApplicationDbContext dbContext) : IColorQueryService
{
    /// <inheritdoc/>
    public async Task<IList<ColorDto>> GetAllBySpeciesAsync(SpeciesType species)
    {
        return await dbContext.Colors.AsNoTracking()
            .Where(c => c.SpeciesType == species)
            .Select(c => c.ToDto())
            .ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<IList<ColorDto>> GetAllAsync()
    {
        return await dbContext.Colors.AsNoTracking()
            .Select(c => c.ToDto())
            .ToListAsync();
    }
}
