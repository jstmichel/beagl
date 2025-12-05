// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.Core.Helpers;
using Beagl.Infrastructure.AnimalManagement.DTOs;

namespace Beagl.Infrastructure.AnimalManagement.Services;

/// <summary>
/// Service interface for dog-related operations.
/// </summary>
public interface IDogService
{
    /// <summary>
    /// Creates a new dog in the system.
    /// </summary>
    /// <param name="createDogDto">The data transfer object containing dog creation details.</param>
    /// <returns>The unique identifier of the newly created dog.</returns>
    public Task<Result<Guid>> CreateDogAsync(CreateDogDto createDogDto);
}
