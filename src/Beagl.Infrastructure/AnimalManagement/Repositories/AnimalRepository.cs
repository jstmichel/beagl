// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Domain.AnimalManagement;
using Beagl.Domain.AnimalManagement.Repositories;
using Beagl.Domain.Core.Interfaces;
using Beagl.Infrastructure.Core.Helpers;

namespace Beagl.Infrastructure.AnimalManagement.Repositories;

/// <summary>
/// Concrete implementation of IAnimalRepository for managing Animal aggregates.
/// </summary>
public class AnimalRepository : IAnimalRepository
{
    /// <inheritdoc/>
    public Task AddAsync(Animal animal) => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<Animal?> GetByIdAsync(Guid id) => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<(IList<Animal> Items, int TotalCount)> GetPagedAsync(
        IPagedFilter filter)
    {
        AnimalPagedFilterDto animalFilter =
            FilterCastingHelper.CastFilterTo<AnimalPagedFilterDto>(filter);

        return Task.FromResult((Items: (IList<Animal>)[], TotalCount: 0));
    }

    /// <inheritdoc/>
    public Task RemoveAsync(Animal animal) => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task UpdateAsync(Animal animal) => throw new NotImplementedException();
}
