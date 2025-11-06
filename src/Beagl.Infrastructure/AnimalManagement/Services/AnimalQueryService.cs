// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Mappers;
using Beagl.Application.AnimalManagement.Services;
using Beagl.Domain.AnimalManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace Beagl.Infrastructure.AnimalManagement.Services;

/// <summary>
/// Concrete implementation of IAnimalQueryService for querying paginated animal list DTOs.
/// </summary>
public sealed class AnimalQueryService (
    ApplicationDbContext dbContext) : IAnimalQueryService
{
    /// <inheritdoc/>
    public async Task<(IList<AnimalListDto> Items, int TotalCount)> GetPagedAsync(AnimalPagedFilterDto filter)
    {
        ArgumentNullException.ThrowIfNull(filter);

        IQueryable<Animal> query = dbContext
            .Animals
            .Include(a => a.PrimaryBreed)
            .Include(a => a.Color)
            .Include(a => a.Citizen)
            .AsNoTracking();

        int totalCount = await query.CountAsync();

        IQueryable<AnimalListDto> projected = query
            .Select(a => a.ToListDto());

        IList<AnimalListDto> items = await projected
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();

        return (items, totalCount);
    }
}
