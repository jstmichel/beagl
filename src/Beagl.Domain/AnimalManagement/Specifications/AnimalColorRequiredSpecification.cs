// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Core.Specifications;

namespace Beagl.Domain.AnimalManagement.Specifications;

/// <summary>
/// Ensures the animal color is not null or whitespace.
/// </summary>
public sealed class AnimalColorRequiredSpecification : ISpecification<string>
{
    /// <summary>
    /// Determines whether the candidate satisfies the specification.
    /// </summary>
    /// <param name="candidate">The color to evaluate.</param>
    /// <returns>A boolean indicating whether the candidate satisfies the specification.</returns>
    public bool IsSatisfiedBy(string candidate)
        => !string.IsNullOrWhiteSpace(candidate);
}
