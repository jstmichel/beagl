// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.WebApp.Mappers;

using System;
using Beagl.Application.AnimalManagement.DTOs;
using Beagl.WebApp.Pages.Animals.ViewModels;

/// <summary>
/// Extension methods for mapping CreateCatViewModel to Cat entity.
/// </summary>
internal static class CreateCatViewModelMappingExtensions
{
    /// <summary>
    /// Maps a <see cref="CreateCatViewModel"/> to a <see cref="CreateCatDto"/> dto.
    /// </summary>
    /// <param name="model">The create cat view model.</param>
    /// <returns>The mapped cat dto.</returns>
    public static CreateCatDto ToDto(this CreateCatViewModel model)
    {
        ArgumentNullException.ThrowIfNull(model);

        return new CreateCatDto
        {
            Name = model.Name,
            BreedPrimaryId = model.BreedPrimaryId!.Value,
            ColorId = model.ColorId!.Value,
            Description = model.Description,
            Gender = model.Gender,
            BirthDate = model.BirthDate!.Value,
            PhotoBase64 = model.PhotoBase64,
            MicrochipNumber = model.MicrochipNumber,
            IsAnUnclawnedCat = model.IsAnUnclawnedCat,
            Weight = model.Weight,
            WeightUnit = model.WeightUnit,
        };
    }
}
