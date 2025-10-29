// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.CitizenManagement.DTOs;
using Beagl.Application.CitizenManagement.Mappers;
using Beagl.Application.CitizenManagement.Services;
using Beagl.Domain.CitizenManagement.Entities;
using Beagl.Domain.CitizenManagement.Repositories;

namespace Beagl.Infrastructure.CitizenManagement.Services;

/// <summary>
/// Implementation of the citizen service.
/// </summary>
/// <seealso cref="ICitizenService"/>
public class CitizenService(
    ICitizenRepository citizenRepository) : ICitizenService
{
    /// <inheritdoc/>
    public async Task<Guid> CreateAsync(CreateCitizenDto createCitizenDto)
    {
        ArgumentNullException.ThrowIfNull(createCitizenDto);

        Citizen newCitizen = createCitizenDto.ToDomain();

        Guid citizenId = await citizenRepository.CreateAsync(newCitizen);
        return citizenId;
    }
}
