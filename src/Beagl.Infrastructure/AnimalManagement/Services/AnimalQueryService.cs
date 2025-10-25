// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Services;
using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.AnimalManagement.ValueObjects;
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

        IQueryable<Animal> query = dbContext.Animals;
        int totalCount = await query.CountAsync();

        IQueryable<AnimalListDto> projected = query
            .Select(a => new AnimalListDto
            {
                Id = a.Id,
                Name = a.Name,
                Breed = a.PrimaryBreed != null ? a.PrimaryBreed.Name : string.Empty,
                Color = a.Color != null ? a.Color.Name : string.Empty,
                BirthDate = a.DateOfBirth,
                MicrochipNumber = a.Microchip != null ? a.Microchip.Value : null,
                Species = a.SpeciesType,
                Gender = a.Gender,
            });

        IList<AnimalListDto> items = await projected
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();

        return (items, totalCount);
    }
}
