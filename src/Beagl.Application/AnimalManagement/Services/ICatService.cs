// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Threading.Tasks;
using Beagl.Application.AnimalManagement.DTOs;

namespace Beagl.Application.AnimalManagement.Services;

/// <summary>
/// Service interface for cat-related operations.
/// </summary>
public interface ICatService
{
    /// <summary>
    /// Creates a new cat in the system.
    /// </summary>
    /// <param name="createCatDto">The data transfer object containing cat creation details.</param>
    /// <returns>The unique identifier of the newly created cat.</returns>
    public Task<Guid> CreateCatAsync(CreateCatDto createCatDto);
}
