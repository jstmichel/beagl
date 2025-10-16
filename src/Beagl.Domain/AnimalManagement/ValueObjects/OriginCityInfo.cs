// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents the origin city information for an animal, including whether it comes from another city and if it had a judgment there.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="OriginCityInfo"/> class.
/// </remarks>
/// <param name="comesFromAnotherCity">Whether the animal comes from another city.</param>
/// <param name="cityName">The name of the city the animal comes from.</param>
/// <param name="hadJudgmentInThatCity">Whether the animal had a judgment in that city.</param>
public sealed class OriginCityInfo(bool comesFromAnotherCity, string cityName, bool hadJudgmentInThatCity)
{
    private OriginCityInfo() : this(default, default!, default) { }

    /// <summary>
    /// Gets a value indicating whether the animal comes from another city.
    /// </summary>
    public bool ComesFromAnotherCity { get; private set; } = comesFromAnotherCity;

    /// <summary>
    /// Gets the name of the city the animal comes from.
    /// </summary>
    public string CityName { get; private set; } = cityName;

    /// <summary>
    /// Gets a value indicating whether the animal had a judgment in that city.
    /// </summary>
    public bool HadJudgmentInThatCity { get; private set; } = hadJudgmentInThatCity;
}
