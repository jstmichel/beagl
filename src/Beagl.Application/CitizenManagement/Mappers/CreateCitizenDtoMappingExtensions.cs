// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Application.CitizenManagement.DTOs;
using Beagl.Application.Core.Helpers;
using Beagl.Domain.CitizenManagement.Entities;
using Beagl.Domain.CitizenManagement.Enums;
using Beagl.Domain.CitizenManagement.ValueObjects;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Application.CitizenManagement.Mappers;

/// <summary>
/// Mapping extensions for CreateCitizenDto.
/// </summary>
public static class CreateCitizenDtoMappingExtensions
{
    /// <summary>
    /// Maps a CreateCitizenDto to a Citizen entity.
    /// </summary>
    /// <param name="createCitizenDto">The DTO to map.</param>
    /// <returns>The mapped Citizen entity.</returns>
    public static Citizen ToDomain(this CreateCitizenDto createCitizenDto)
    {
        ArgumentNullException.ThrowIfNull(createCitizenDto);

        return new(
            new PersonName(
                EnumHelper.FromInt<Civility>(createCitizenDto.Civility),
                createCitizenDto.FirstName,
                createCitizenDto.LastName),
            PhoneNumber.From(createCitizenDto.Phone),
            PhoneNumber.From(createCitizenDto.CellPhone),
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
                createCitizenDto.PostOfficeBox,
                Audit.From(Guid.Empty, DateTimeOffset.UtcNow.ToUniversalTime())
            ),
            Audit.From(Guid.Empty, DateTimeOffset.UtcNow.ToUniversalTime()));
    }
}
