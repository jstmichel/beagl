// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Services;
using Beagl.Infrastructure.AnimalManagement.Models;
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

        IQueryable<AnimalModel> query = dbContext.Animals;
        int totalCount = await query.CountAsync();
        IList<AnimalListDto> items = await query
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(a => new AnimalListDto
            {
                Id = a.Id,
                Name = a.Name,
                // Species = a.Species,
                // Breed = a.Breed.Primary,
                // Color = a.Color,
                //Gender = a.Gender,
                BirthDate = a.DateOfBirth,
                MicrochipNumber = a.Microchip!.value,
            })
            .ToListAsync();
            return (items, totalCount);
    }
}
