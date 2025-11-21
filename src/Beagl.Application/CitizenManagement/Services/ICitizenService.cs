// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Threading.Tasks;
using Beagl.Application.CitizenManagement.DTOs;
using Beagl.Application.Core.Helpers;

namespace Beagl.Application.CitizenManagement.Services;

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
