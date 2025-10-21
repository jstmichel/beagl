// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Services;
using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.AnimalManagement.ValueObjects;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Infrastructure.AnimalManagement.Services;

/// <summary>
/// Implementation of cat-related operations.
/// </summary>
public sealed class CatService : ICatService
{
    /// <inheritdoc />
    public Task<Guid> CreateCatAsync(CreateCatDto createCatDto)
    {
        ArgumentNullException.ThrowIfNull(createCatDto);

        Cat newCat = new(
            name: createCatDto.Name,
            primaryBreedId: createCatDto.BreedPrimaryId,
            colorId: createCatDto.ColorId,
            distinctiveDescription: createCatDto.Description ?? string.Empty,
            gender: GenderHelper.FromInt(createCatDto.Gender),
            birthDate: createCatDto.BirthDate,
            isAnUnclawnedCat: createCatDto.IsAnUnclawnedCat,
            photo: Photo.From(createCatDto.PhotoBase64),
            microchip: Microchip.From(createCatDto.MicrochipNumber),
            createdByUserId: Guid.Empty,
            createdAt: DateTimeOffset.UtcNow.ToUniversalTime()
        );

        // Implementation to save the new cat to the database would go here.
        throw new NotImplementedException();
    }
}
