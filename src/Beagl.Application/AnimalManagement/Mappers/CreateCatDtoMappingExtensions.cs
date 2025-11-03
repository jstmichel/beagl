// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.Core.Helpers;
using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.AnimalManagement.Enums;
using Beagl.Domain.AnimalManagement.ValueObjects;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Application.AnimalManagement.Mappers;

/// <summary>
/// Mapping extensions for CreateCatDto.
/// </summary>
public static class CreateCatDtoMappingExtensions
{
    /// <summary>
    /// Maps a CreateCatDto to a Cat entity.
    /// </summary>
    /// <param name="createCatDto">The DTO to map.</param>
    /// <returns>The mapped Cat entity.</returns>
    /// <exception cref="ArgumentNullException">Thrown when createCatDto is null.</exception>
    public static Cat ToDomain(this CreateCatDto createCatDto)
    {
        ArgumentNullException.ThrowIfNull(createCatDto);

        return new(
            SpeciesType.Cat,
            createCatDto.Name,
            createCatDto.BreedPrimaryId,
            null,
            createCatDto.ColorId,
            null,
            createCatDto.Description ?? string.Empty,
            EnumHelper.FromInt<Gender>(createCatDto.Gender),
            createCatDto.BirthDate.ToUniversalTime(), //FIXME:Find a solution for the repository layer to transform to UTC
            Photo.From(createCatDto.PhotoBase64),
            Microchip.From(createCatDto.MicrochipNumber),
            Weight.From(createCatDto.Weight, EnumHelper.FromInt<WeightUnit>(createCatDto.WeightUnit)),
            Medal.From(createCatDto.Medal),
            Audit.From(Guid.Empty, DateTimeOffset.UtcNow.ToUniversalTime()),  //TODO: Replace with actual user ID
            createCatDto.IsAnUnclawnedCat
        );
    }
}
