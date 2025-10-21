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
public record class OriginCityInfo(
    bool comesFromAnotherCity,
    string cityName,
    bool hadJudgmentInThatCity);
