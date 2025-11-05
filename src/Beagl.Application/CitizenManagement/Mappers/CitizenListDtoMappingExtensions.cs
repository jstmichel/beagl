// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Linq;
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
    /// <exception cref="ArgumentNullException">Thrown when the citizen parameter is null.</exception>
    public static CitizenListDto ToListDto(this Citizen citizen)
    {
        ArgumentNullException.ThrowIfNull(citizen);

        return new CitizenListDto
        {
            Id = citizen.Id,
            Name = citizen.Person.ToDisplayString(),
            Phone = citizen.Phone?.ToDisplayString(),
            CellPhone = citizen.CellPhone?.ToDisplayString(),
            Email = citizen.Email,
            AnimalsCount = 0,
            Address = citizen.Addresses
                .OrderByDescending(a => a.Created.At)
                .FirstOrDefault()?.ToDisplayString()
        };
    }

    /// <summary>
    /// Maps a Citizen entity to a CitizenLookupDto.
    /// </summary>
    /// <param name="citizen">The Citizen entity to map.</param>
    /// <returns>The mapped CitizenLookupDto.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the citizen parameter is null.</exception>
    public static CitizenLookupDto ToLookupDto(this Citizen citizen)
    {
        ArgumentNullException.ThrowIfNull(citizen);

        return new CitizenLookupDto
        {
            Id = citizen.Id,
            Civility = citizen.Person.CivilityAsString(),
            Name = citizen.Person.ToDisplayString(),
        };
    }
}
