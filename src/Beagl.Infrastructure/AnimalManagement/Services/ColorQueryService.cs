// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Services;
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
    public async Task<IList<ColorDto>> GetAllAsync()
    {
        return await dbContext.Colors
            .Select(c => new ColorDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();
    }
}
