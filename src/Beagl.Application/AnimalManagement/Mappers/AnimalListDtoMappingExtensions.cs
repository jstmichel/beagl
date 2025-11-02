// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.AnimalManagement.Enums;

namespace Beagl.Application.AnimalManagement.Mappers;

/// <summary>
/// Extension methods for mapping Animal entities to DTOs.
/// </summary>
public static class AnimalListDtoMappingExtensions
{
    /// <summary>
    /// Maps an Animal entity to an AnimalListDto.
    /// </summary>
    /// <param name="animal">The Animal entity.</param>
    /// <returns>The mapped AnimalListDto.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the animal parameter is null.</exception>
    public static AnimalListDto ToListDto(this Animal animal)
    {
        ArgumentNullException.ThrowIfNull(animal);

        return new AnimalListDto
        {
            Id = animal.Id,
            Name = animal.Name,
            PrimaryBreed = animal.PrimaryBreed != null ? animal.PrimaryBreed.Name : string.Empty,
            Color = animal.Color != null ? animal.Color.Name : string.Empty,
            BirthDate = animal.DateOfBirth,
            MicrochipNumber = animal.Microchip?.Value,
            Species = animal.SpeciesType,
            Gender = animal.Gender,
            Base64PngImage = animal.Photo?.Base64Png,
            DistinctiveDescription = animal.DistinctiveDescription,
            Weight = animal.Weight?.Value,
            WeightUnit = animal.Weight?.Unit ?? WeightUnit.Kilograms,
            PermitNumber = "F_REPLACE_ME"
        };
    }
}
