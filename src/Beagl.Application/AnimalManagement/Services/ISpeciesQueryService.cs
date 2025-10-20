// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Collections.Generic;
using System.Threading.Tasks;
using Beagl.Application.AnimalManagement.DTOs;

namespace Beagl.Application.AnimalManagement.Services;

/// <summary>
/// Service for querying available species for animals.
/// </summary>
public interface ISpeciesQueryService
{
    /// <summary>
    /// Gets all available species for dropdowns.
    /// </summary>
    /// <returns>List of species DTOs.</returns>
    public Task<IList<SpeciesDto>> GetAllAsync();
}
