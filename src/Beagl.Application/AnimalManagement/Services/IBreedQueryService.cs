// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Collections.Generic;
using System.Threading.Tasks;
using Beagl.Application.AnimalManagement.DTOs;

namespace Beagl.Application.AnimalManagement.Services;

/// <summary>
/// Service for querying available breeds for animals.
/// </summary>
public interface IBreedQueryService
{
    /// <summary>
    /// Gets all available breeds for dropdowns.
    /// </summary>
    /// <returns>List of breed DTOs.</returns>
    public Task<IList<BreedDto>> GetAllAsync();
}
