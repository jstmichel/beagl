// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.AnimalManagement.Enums;
using Beagl.Infrastructure.AnimalManagement.DTOs;
using Beagl.Infrastructure.AnimalManagement.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Beagl.Infrastructure.AnimalManagement.Services;

/// <summary>
/// Concrete implementation of IAnimalQueryService for querying paginated animal list DTOs.
/// </summary>
public sealed class AnimalQueryService(
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

        query = ApplyFiltersToQuery(query, filter);

        int totalCount = await query.CountAsync();

        IQueryable<AnimalListDto> projected = query
            .Select(a => a.ToListDto());

        IList<AnimalListDto> items = await projected
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();

        return (items, totalCount);
    }

    private static IQueryable<Animal> ApplyFiltersToQuery(
        IQueryable<Animal> query,
        AnimalPagedFilterDto filter)
    {
        ArgumentNullException.ThrowIfNull(query);
        ArgumentNullException.ThrowIfNull(filter);

        query = ApplyNameFilterToQuery(query, filter.Name);
        query = ApplySpeciesFilterToQuery(query, filter.Species);
        query = ApplyPrimaryBreedFilterToQuery(query, filter.PrimaryBreed);
        query = ApplyColorFilterToQuery(query, filter.Color);
        query = ApplyGenderFilterToQuery(query, filter.Gender);
        query = ApplyMicrochipNumberFilterToQuery(query, filter.MicrochipNumber);
        query = ApplyPermitNumberFilterToQuery(query, filter.PermitNumber);

        return query;
    }

    private static IQueryable<Animal> ApplyNameFilterToQuery(
        IQueryable<Animal> query,
        string? name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            query = query.Where(u => u.Name!.Contains(name));
        }

        return query;
    }

    private static IQueryable<Animal> ApplySpeciesFilterToQuery(
        IQueryable<Animal> query,
        SpeciesType? species)
    {
        if (species.HasValue)
        {
            query = query.Where(u => u.SpeciesType == species.Value);
        }

        return query;
    }

    private static IQueryable<Animal> ApplyPrimaryBreedFilterToQuery(
        IQueryable<Animal> query,
        Guid? primaryBreedId)
    {
        if (primaryBreedId.HasValue)
        {
            query = query.Where(u => u.PrimaryBreedId == primaryBreedId.Value);
        }

        return query;
    }

    private static IQueryable<Animal> ApplyColorFilterToQuery(
        IQueryable<Animal> query,
        Guid? colorId)
    {
        if (colorId.HasValue)
        {
            query = query.Where(u => u.ColorId == colorId.Value);
        }

        return query;
    }

    private static IQueryable<Animal> ApplyGenderFilterToQuery(
        IQueryable<Animal> query,
        Gender? gender)
    {
        if (gender.HasValue)
        {
            query = query.Where(u => u.Gender == gender.Value);
        }

        return query;
    }

    private static IQueryable<Animal> ApplyMicrochipNumberFilterToQuery(
        IQueryable<Animal> query,
        string? microchipNumber)
    {
        if (!string.IsNullOrWhiteSpace(microchipNumber))
        {
            query = query.Where(u => u.Microchip!.Value.Contains(microchipNumber));
        }

        return query;
    }

    private static IQueryable<Animal> ApplyPermitNumberFilterToQuery(
        IQueryable<Animal> query,
        string? permitNumber)
    {
        if (!string.IsNullOrWhiteSpace(permitNumber))
        {
            query = query.Where(u => u.Medal!.Value.Contains(permitNumber));
        }

        return query;
    }
}
