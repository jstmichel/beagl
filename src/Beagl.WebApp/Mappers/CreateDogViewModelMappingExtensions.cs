// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.WebApp.Mappers;

using System;
using Beagl.Application.AnimalManagement.DTOs;
using Beagl.WebApp.Pages.Animals.ViewModels;

/// <summary>
/// Extension methods for mapping CreateDogViewModel to Dog entity.
/// </summary>
internal static class CreateDogViewModelMappingExtensions
{
    /// <summary>
    /// Maps a <see cref="CreateDogViewModel"/> to a <see cref="CreateDogDto"/> dto.
    /// </summary>
    /// <param name="model">The create dog view model.</param>
    /// <returns>The mapped dog dto.</returns>
    public static CreateDogDto ToDto(this CreateDogViewModel model)
    {
        ArgumentNullException.ThrowIfNull(model);

        return new CreateDogDto
        {
            Name = model.Name,
            BreedPrimaryId = model.BreedPrimaryId!.Value,
            BreedSecondaryId = model.BreedSecondaryId,
            ColorId = model.ColorId!.Value,
            Description = model.Description,
            Gender = model.Gender,
            BirthDate = model.BirthDate!.Value,
            PhotoBase64 = model.PhotoBase64,
            MicrochipNumber = model.MicrochipNumber,
            Weight = model.Weight,
            WeightUnit = model.WeightUnit,
            Medal = model.Medal,
            IsSterilized = model.IsSterilized,
            RabiesVaccinationDate = model.RabiesVaccinationDate,
            IsRabiesVaccinated = model.IsRabiesVaccinated,
            IsAnAssistanceDog = model.IsAnAssistanceDog,
            IsDangerousDog = model.IsDangerousDog,
            HasResponsibilityInsurance = model.HasResponsibilityInsurance,
            DangerousDogComment = model.DangerousDogComment,
            ComesFromAnotherCity = model.ComesFromAnotherCity,
            OriginCityName = model.OriginCityName,
            HadJudgmentInThatCity = model.HadJudgmentInThatCity
        };
    }
}
