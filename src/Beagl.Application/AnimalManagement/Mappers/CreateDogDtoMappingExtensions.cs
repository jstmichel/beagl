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
/// Mapping extensions for CreateDogDto.
/// </summary>
public static class CreateDogDtoMappingExtensions
{
    /// <summary>
    /// Maps a CreateDogDto to a Dog entity.
    /// </summary>
    /// <param name="createDogDto">The DTO to map.</param>
    /// <returns>The mapped Dog entity.</returns>
    /// <exception cref="ArgumentNullException">Thrown when createDogDto is null.</exception>
    public static Dog ToDomain(this CreateDogDto createDogDto)
    {
        ArgumentNullException.ThrowIfNull(createDogDto);

        return new(
            SpeciesType.Dog,
            createDogDto.Name,
            createDogDto.BreedPrimaryId,
            createDogDto.ColorId,
            createDogDto.Description ?? string.Empty,
            EnumHelper.FromInt<Gender>(createDogDto.Gender),
            createDogDto.BirthDate.ToUniversalTime(), //FIXME:Find a solution for the repository layer to transform to UTC
            Photo.From(createDogDto.PhotoBase64),
            Microchip.From(createDogDto.MicrochipNumber),
            Weight.From(createDogDto.Weight, EnumHelper.FromInt<WeightUnit>(createDogDto.WeightUnit)),
            Audit.From(Guid.Empty, DateTimeOffset.UtcNow.ToUniversalTime()), //TODO: Replace with actual user ID
            createDogDto.BreedSecondaryId,
            null, //TODO: Missing fields
            false, //TODO: Missing fields
            null, //TODO: Missing fields
            Medal.From(createDogDto.Medal)
        );
    }
}
