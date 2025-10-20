// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Domain.AnimalManagement;
using Beagl.Domain.AnimalManagement.Repositories;
using Beagl.Domain.Core.Interfaces;
using Beagl.Infrastructure.AnimalManagement.Extensions;
using Beagl.Infrastructure.AnimalManagement.Models;
using Beagl.Infrastructure.Core.Extensions;
using Beagl.Infrastructure.Core.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Beagl.Infrastructure.AnimalManagement.Repositories;

/// <summary>
/// Concrete implementation of IAnimalRepository for managing Animal aggregates.
/// </summary>
public class AnimalRepository
    (ApplicationDbContext dbContext) : IAnimalRepository, IPagedService<AnimalListDto, IPagedFilter>
{
    /// <inheritdoc/>
    public Task AddAsync(Animal animal)
    {
        AnimalModel entity = animal.ToEntity();
        dbContext.Animals.Add(entity);
        return dbContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public Task<Animal?> GetByIdAsync(Guid id) => throw new NotImplementedException();

    /// <inheritdoc/>
    public async Task<(IList<AnimalListDto> Items, int TotalCount)> GetPagedAsync(
        IPagedFilter filter)
    {
        ArgumentNullException.ThrowIfNull(filter);

        AnimalPagedFilterDto animalFilter =
            FilterCastingHelper.CastFilterTo<AnimalPagedFilterDto>(filter);

        IQueryable<AnimalModel> query = dbContext.Animals;
        //query = ApplyFiltersToQuery(query, animalFilter);
        //query = ApplyOrderingByUsernameToQuery(query);
        int totalCount = 1; //await GetCountAsync(query);

        List<AnimalModel> animals = await query
             .Paginate(animalFilter.PageNumber, animalFilter.PageSize)
             .ToListAsync();

        List<AnimalListDto> animalDtos = [.. animals.Select(a => a.ToListDto())];

        return (Items: animalDtos, TotalCount: totalCount);
    }

    /// <inheritdoc/>
    public Task RemoveAsync(Animal animal) => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task UpdateAsync(Animal animal) => throw new NotImplementedException();
}
