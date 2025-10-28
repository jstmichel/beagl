// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.AnimalManagement.Enums;

namespace Beagl.WebApp.Services;

/// <summary>
/// Service for localizing static data values.
/// </summary>
public interface IStaticDataLocalizerService
{
    /// <summary>
    /// Localizes the gender value.
    /// </summary>
    /// <param name="gender">The gender to localize.</param>
    /// <returns>The localized gender string.</returns>
    public string LocalizeGender(Gender gender);

    /// <summary>
    /// Localizes the species value.
    /// </summary>
    /// <param name="species">The species to localize.</param>
    /// <returns>The localized species string.</returns>
    public string LocalizeSpecies(SpeciesType species);
}
