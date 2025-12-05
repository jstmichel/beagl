// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.Core.Helpers;
using Beagl.Domain.CitizenManagement.Entities;
using Beagl.Domain.CitizenManagement.Repositories;
using Beagl.Domain.Core.Exceptions;
using Beagl.Infrastructure.CitizenManagement.DTOs;
using Beagl.Infrastructure.CitizenManagement.Mappers;

namespace Beagl.Infrastructure.CitizenManagement.Services;

/// <summary>
/// Implementation of the citizen service.
/// </summary>
/// <seealso cref="ICitizenService"/>
public class CitizenService(
    ICitizenRepository citizenRepository) : ICitizenService
{
    /// <inheritdoc/>
    public async Task<Result<Guid>> CreateAsync(CreateCitizenDto createCitizenDto)
    {
        ArgumentNullException.ThrowIfNull(createCitizenDto);

        try
        {
            Citizen newCitizen = createCitizenDto.ToDomain();
            Guid citizenId = await citizenRepository.CreateAsync(newCitizen);
            return ApplicationResult.Ok(citizenId);
        }
        catch (DomainException ex)
        {
            return ApplicationResult.Fail<Guid>(ex.ErrorCode, ex.Message);
        }
    }
}
