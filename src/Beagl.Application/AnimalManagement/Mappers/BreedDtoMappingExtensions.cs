// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Domain.AnimalManagement.Entities;

namespace Beagl.Application.AnimalManagement.Mappers;

/// <summary>
/// Mapping extensions for BreedDto.
/// </summary>
public static class BreedDtoMappingExtensions
{
    /// <summary>
    /// Maps a Breed entity to a Breed DTO.
    /// </summary>
    /// <param name="breed">The entity to map.</param>
    /// <returns>The mapped Breed DTO.</returns>
    /// <exception cref="ArgumentNullException">Thrown when breed is null.</exception>
    public static BreedDto ToDto(this Breed breed)
    {
        ArgumentNullException.ThrowIfNull(breed);

        return new BreedDto
        {
            Id = breed.Id,
            Name = breed.Name
        };
    }
}
