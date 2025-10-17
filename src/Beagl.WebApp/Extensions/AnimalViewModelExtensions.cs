// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Application.AnimalManagement.DTOs;
using Beagl.WebApp.Pages.Animals.ViewModels;

namespace Beagl.WebApp.Extensions;

/// <summary>
/// Extension methods for AnimalViewModel.
/// </summary>
public static class AnimalViewModelExtensions
{
    /// <summary>
    /// Maps the CreateUpdateAnimalViewModel to the AnimalDTO.
    /// </summary>
    /// <param name="viewModel">The view model.</param>
    /// <returns>The mapped DTO.</returns>
    public static AnimalDto MapToDataTransferObject(
        this CreateAnimalViewModel viewModel)
    {
        ArgumentNullException.ThrowIfNull(viewModel);

        return new AnimalDto
        {
            Id = viewModel.Id,
            Name = viewModel.Name,
            Species = viewModel.Species,
            Breed = viewModel.Breed,
            Color = viewModel.Color,
            DistinctiveDescription = viewModel.DistinctiveDescription,
            Gender = viewModel.Gender,
            BirthDate = viewModel.BirthDate,
            PhotoBase64 = viewModel.PhotoBase64,
            MicrochipNumber = viewModel.MicrochipNumber,
            PermitNumber = viewModel.PermitNumber,
            IsDangerousDog = viewModel.IsDangerousDog,
            IsAnAssistanceDog = viewModel.IsAnAssistanceDog,
            IsAnUnclawnedCat = viewModel.IsAnUnclawnedCat,
            ComesFromAnotherCity = viewModel.ComesFromAnotherCity,
            CityName = viewModel.CityName,
            HadJudgmentInThatCity = viewModel.HadJudgmentInThatCity,
        };
    }
}
