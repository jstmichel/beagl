// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents the origin city information for an animal, including whether it comes from another city and if it had a judgment there.
/// </summary>
public class OriginCityInfo
{
    /// <summary>
    /// Gets a value indicating whether the animal comes from another city.
    /// </summary>
    public bool ComesFromAnotherCity { get; private set; }

    /// <summary>
    /// Gets the name of the city.
    /// </summary>
    public string CityName { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the animal had a judgment in that city.
    /// </summary>
    public bool HadJudgmentInThatCity { get; private set; }

    private OriginCityInfo(bool comesFromAnotherCity, string cityName, bool hadJudgmentInThatCity)
    {
        ComesFromAnotherCity = comesFromAnotherCity;
        CityName = cityName;
        HadJudgmentInThatCity = hadJudgmentInThatCity;
    }

    /// <summary>
    /// Creates an OriginCityInfo value object from the given parameters.
    /// </summary>
    /// <param name="comesFromAnotherCity">Indicates if the animal comes from another city.</param>
    /// <param name="cityName">The name of the city.</param>
    /// <param name="hadJudgmentInThatCity">Indicates if the animal had a judgment in that city.</param>
    /// <returns>An OriginCityInfo value object or null if any input is invalid.</returns>
    public static OriginCityInfo? From(bool? comesFromAnotherCity, string? cityName, bool? hadJudgmentInThatCity)
    {
        if (comesFromAnotherCity is null || hadJudgmentInThatCity is null || string.IsNullOrWhiteSpace(cityName))
            return null;
        return new OriginCityInfo(comesFromAnotherCity.Value, cityName, hadJudgmentInThatCity.Value);
    }
}
