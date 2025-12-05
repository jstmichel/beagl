// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.AnimalManagement.Enums;
using Beagl.Infrastructure.AnimalManagement.DTOs;

namespace Beagl.Infrastructure.AnimalManagement.Services;

/// <summary>
/// Service for querying available breeds for animals.
/// </summary>
public interface IBreedQueryService
{
    /// <summary>
    /// Gets all available breeds for dropdowns.
    /// </summary>
    /// <returns>List of breed DTOs.</returns>
    public Task<IList<BreedDto>> GetAllBySpeciesAsync(SpeciesType species);

    /// <summary>
    /// Gets all available breeds.
    /// </summary>
    /// <returns>List of breed DTOs.</returns>
    public Task<IList<BreedDto>> GetAllAsync();
}
