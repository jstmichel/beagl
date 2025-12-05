// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Infrastructure.AnimalManagement.DTOs;

namespace Beagl.Infrastructure.AnimalManagement.Mappers;

/// <summary>
/// Mapping extensions for ColorDto.
/// </summary>
public static class ColorDtoMappingExtensions
{
    /// <summary>
    /// Maps a Color entity to a Color DTO.
    /// </summary>
    /// <param name="color">The entity to map.</param>
    /// <returns>The mapped Color DTO.</returns>
    /// <exception cref="ArgumentNullException">Thrown when color is null.</exception>
    public static ColorDto ToDto(this Color color)
    {
        ArgumentNullException.ThrowIfNull(color);

        return new ColorDto
            {
                Id = color.Id,
                Name = color.Name
            };
    }
}
