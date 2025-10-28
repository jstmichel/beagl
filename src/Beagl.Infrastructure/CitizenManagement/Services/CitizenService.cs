// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.CitizenManagement.DTOs;
using Beagl.Application.CitizenManagement.Services;
using Beagl.Application.Core.Helpers;
using Beagl.Domain.CitizenManagement.Entities;
using Beagl.Domain.CitizenManagement.Repositories;
using Beagl.Domain.CitizenManagement.ValueObjects;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Infrastructure.CitizenManagement.Services;

/// <summary>
/// Implementation of the citizen service.
/// </summary>
/// <seealso cref="Beagl.Application.CitizenManagement.Services.ICitizenService"/>
public class CitizenService(
    ICitizenRepository citizenRepository) : ICitizenService
{
    /// <inheritdoc/>
    public async Task<Guid> CreateAsync(CreateCitizenDto createCitizenDto)
    {
        ArgumentNullException.ThrowIfNull(createCitizenDto);

        Citizen newCitizen = new(
            new PersonName(
                EnumHelper.FromInt<Civility>(createCitizenDto.Civility),
                createCitizenDto.FirstName,
                createCitizenDto.LastName),
            createCitizenDto.Phone,
            createCitizenDto.CellPhone,
            EnumHelper.FromInt<CommunicationPreference>(createCitizenDto.CommunicationPreference),
            EnumHelper.FromInt<LanguagePreference>(createCitizenDto.LanguagePreference),
            createCitizenDto.Email,
            new Address(
                createCitizenDto.StreetNumber,
                createCitizenDto.StreetName,
                createCitizenDto.Appartment,
                createCitizenDto.City,
                createCitizenDto.Province,
                createCitizenDto.Country,
                createCitizenDto.PostalCode,
                createCitizenDto.PostOfficeBox
            ),
            Audit.From(Guid.Empty, DateTimeOffset.UtcNow.ToUniversalTime()));

        Guid citizenId = await citizenRepository.CreateAsync(newCitizen);
        return citizenId;
    }
}
