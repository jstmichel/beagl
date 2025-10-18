// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Core.Specifications;

namespace Beagl.Domain.AnimalManagement.Specifications;

/// <summary>
/// Ensures only dogs can be marked as assistance animals.
/// </summary>
public sealed class AnimalAssistanceDogSpeciesSpecification : ISpecification<(string Species, bool IsAssistanceDog)>
{
    /// <summary>
    /// Determines whether the candidate satisfies the specification.
    /// </summary>
    /// <param name="candidate">Species and assistance dog status</param>
    /// <returns>A boolean indicating whether the candidate satisfies the specification</returns>
    public bool IsSatisfiedBy((string Species, bool IsAssistanceDog) candidate)
    {
        return !candidate.IsAssistanceDog ||
            candidate.Species.Equals("dog", System.StringComparison.OrdinalIgnoreCase);
    }
}
