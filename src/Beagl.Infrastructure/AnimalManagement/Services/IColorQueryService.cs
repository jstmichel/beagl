// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.AnimalManagement.Enums;
using Beagl.Infrastructure.AnimalManagement.DTOs;

namespace Beagl.Infrastructure.AnimalManagement.Services;

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

    /// <summary>
    /// Gets all available colors.
    /// </summary>
    /// <returns>List of color DTOs.</returns>
    public Task<IList<ColorDto>> GetAllAsync();

}
