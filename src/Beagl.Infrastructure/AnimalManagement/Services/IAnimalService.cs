// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.Core.Helpers;
using Beagl.Infrastructure.AnimalManagement.DTOs;

namespace Beagl.Infrastructure.AnimalManagement.Services;

/// <summary>
/// Service interface for animal-related operations.
/// </summary>
public interface IAnimalService
{
    /// <summary>
    /// Creates a new cat in the system.
    /// </summary>
    /// <param name="createCatDto">The data transfer object containing cat creation details.</param>
    /// <returns>The unique identifier of the newly created cat.</returns>
    public Task<Result<Guid>> CreateCatAsync(CreateCatDto createCatDto);

    /// <summary>
    /// Creates a new dog in the system.
    /// </summary>
    /// <param name="createDogDto">The data transfer object containing dog creation details.</param>
    /// <returns>The unique identifier of the newly created dog.</returns>
    public Task<Result<Guid>> CreateDogAsync(CreateDogDto createDogDto);
}
