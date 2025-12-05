// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.CitizenManagement.DTOs;
using Beagl.WebApp.Pages.Citizens.ViewModels;

namespace Beagl.WebApp.Mappers;

/// <summary>
/// Extension methods for mapping to <see cref="ListCitizensViewModel"/>.
/// </summary>
internal static class ListCitizensViewModelMappingExtensions
{
    /// <summary>
    /// Maps a <see cref="CitizenListDto"/> to a <see cref="ListCitizensViewModel"/>.
    /// </summary>
    /// <param name="dto">The DTO to map.</param>
    /// <returns>The mapped ViewModel.</returns>
    public static ListCitizensViewModel ToViewModel(this CitizenListDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        return new ListCitizensViewModel
        {
            Id = dto.Id,
            Name = dto.Name,
            Phone = dto.Phone,
            CellPhone = dto.CellPhone,
            Email = dto.Email,
            AnimalsCount = dto.AnimalsCount,
            Address = dto.Address
        };
    }
}
