// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.WebApp.Pages.Animals.ViewModels;

namespace Beagl.WebApp.Mappers;

/// <summary>
/// Extension methods for mapping to <see cref="ListAnimalsViewModel"/>.
/// </summary>
internal static class ListAnimalsViewModelMappingExtensions
{
    /// <summary>
    /// Maps a <see cref="AnimalListDto"/> to a <see cref="ListAnimalsViewModel"/>.
    /// </summary>
    /// <param name="dto">The DTO to map.</param>
    /// <returns>The mapped ViewModel.</returns>
    public static ListAnimalsViewModel ToViewModel(this AnimalListDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        return new ListAnimalsViewModel
        {
            Id = dto.Id,
            Name = dto.Name,
            Species = dto.Species,
            Breed = dto.Breed,
            Color = dto.Color,
            Gender = dto.Gender,
            BirthDate = dto.BirthDate,
            MicrochipNumber = dto.MicrochipNumber
        };
    }
}
