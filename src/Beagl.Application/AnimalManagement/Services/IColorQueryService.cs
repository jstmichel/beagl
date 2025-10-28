// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Collections.Generic;
using System.Threading.Tasks;
using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Domain.AnimalManagement.Enums;

namespace Beagl.Application.AnimalManagement.Services;

/// <summary>
/// Service for querying available colors for animals.
/// </summary>
public interface IColorQueryService
{
    /// <summary>
    /// Gets all available colors for dropdowns.
    /// </summary>
    /// <returns>List of color DTOs.</returns>
    public Task<IList<ColorDto>> GetAllBySpeciesAsync(SpeciesType species);
}
