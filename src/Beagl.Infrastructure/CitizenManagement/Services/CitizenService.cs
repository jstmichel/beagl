// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.CitizenManagement.DTOs;
using Beagl.Application.CitizenManagement.Services;

namespace Beagl.Infrastructure.CitizenManagement.Services;

/// <summary>
/// Implementation of the citizen service.
/// </summary>
/// <seealso cref="Beagl.Application.CitizenManagement.Services.ICitizenService"/>
public class CitizenService : ICitizenService
{
    /// <inheritdoc/>
    public Task<Guid> CreateAsync(CreateCitizenDto createCitizenDto)
    {
        // Implementation for creating a citizen goes here.
        throw new NotImplementedException();
    }
}
