// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.AnimalManagement.Enums;
using Microsoft.Extensions.Localization;

namespace Beagl.WebApp.Services;

/// <summary>
/// Service for localizing static data values.
/// </summary>
public class StaticDataLocalizerService(
    IStringLocalizer<StaticDataLocalizerService> localizer) : IStaticDataLocalizerService
{
    /// <summary>
    /// Localizes the gender value.
    /// </summary>
    /// <param name="gender">The gender to localize.</param>
    /// <returns>The localized gender string.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when an unsupported gender is provided.</exception>
    public string LocalizeGender(Gender gender)
    {
        return gender switch
        {
            Gender.Male => localizer["Male"],
            Gender.Female => localizer["Female"],
            Gender.Unknown => localizer["Unknown"],
            _ => throw new ArgumentOutOfRangeException(nameof(gender), gender, null)
        };
    }

    /// <summary>
    /// Localizes the species value.
    /// </summary>
    /// <param name="species">The species to localize.</param>
    /// <returns>The localized species string.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when an unsupported species is provided.</exception>
    public string LocalizeSpecies(SpeciesType species)
    {
        return species switch
        {
            SpeciesType.Cat => localizer["Cat"],
            SpeciesType.Dog => localizer["Dog"],
            SpeciesType.Unknown => localizer["Unknown"],
            _ => throw new ArgumentOutOfRangeException(nameof(species), species, null)
        };
    }
}
