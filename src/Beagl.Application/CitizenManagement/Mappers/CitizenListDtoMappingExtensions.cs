// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Application.CitizenManagement.DTOs;
using Beagl.Domain.CitizenManagement.Entities;

namespace Beagl.Application.CitizenManagement.Mappers;

/// <summary>
/// Extension methods for mapping Citizen entities to CitizenListDto.
/// </summary>
public static class CitizenListDtoMappingExtensions
{
    /// <summary>
    /// Maps a Citizen entity to a CitizenListDto.
    /// </summary>
    /// <param name="citizen">The Citizen entity to map.</param>
    /// <returns>The mapped CitizenListDto.</returns>
    public static CitizenListDto ToListDto(this Citizen citizen)
    {
        ArgumentNullException.ThrowIfNull(citizen);

        return new CitizenListDto
        {
            Id = citizen.Id,
            Name = citizen.Person.FirstName,
            Phone = citizen.Phone,
            CellPhone = citizen.CellPhone,
            Email = citizen.Email,
            AnimalsCount = 0,
        };
    }
}
