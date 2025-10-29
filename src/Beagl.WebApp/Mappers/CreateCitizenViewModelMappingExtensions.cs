// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.WebApp.Mappers;

using System;
using Beagl.Application.CitizenManagement.DTOs;
using Beagl.WebApp.Pages.Citizens.ViewModels;

/// <summary>
/// Extension methods for mapping CreateCitizenViewModel to Citizen entity.
/// </summary>
internal static class CreateCitizenViewModelMappingExtensions
{
    /// <summary>
    /// Maps a <see cref="CreateCitizenViewModel"/> to a <see cref="CreateCitizenDto"/> dto.
    /// </summary>
    /// <param name="model">The create citizen view model.</param>
    /// <returns>The mapped citizen dto.</returns>
    public static CreateCitizenDto ToDto(this CreateCitizenViewModel model)
    {
        ArgumentNullException.ThrowIfNull(model);

        return new()
        {
            Civility = model.Civility,
            FirstName = model.FirstName!,
            LastName = model.LastName!,
            Phone = model.Phone,
            CellPhone = model.CellPhone,
            CommunicationPreference = model.CommunicationPreference,
            LanguagePreference = model.LanguagePreference,
            Email = model.Email,
            StreetNumber = model.StreetNumber!,
            StreetName = model.StreetName!,
            Appartment = model.Appartment,
            City = model.City!,
            Province = model.Province!,
            PostalCode = model.PostalCode!,
            Country = model.Country!,
            PostOfficeBox = model.PostOfficeBox!,
        };
    }
}
