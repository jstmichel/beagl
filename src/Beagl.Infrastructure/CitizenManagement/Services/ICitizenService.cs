// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.Core.Helpers;
using Beagl.Infrastructure.CitizenManagement.DTOs;

namespace Beagl.Infrastructure.CitizenManagement.Services;

/// <summary>
/// Service interface for managing citizens.
/// </summary>
public interface ICitizenService
{
    /// <summary>
    /// Creates a new citizen in the system.
    /// </summary>
    /// <param name="createCitizenDto">The data transfer object containing citizen creation details.</param>
    /// <returns>The unique identifier of the newly created citizen.</returns>
    public Task<Result<Guid>> CreateAsync(CreateCitizenDto createCitizenDto);
}
