// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.Core.Specifications;

/// <summary>
/// Represents a business rule specification.
/// </summary>
/// <typeparam name="T">The type to evaluate.</typeparam>
public interface ISpecification<T>
{
    /// <summary>
    /// Determines whether the specification is satisfied by the given candidate.
    /// </summary>
    /// <param name="candidate">The candidate to evaluate.</param>
    /// <returns>True if satisfied; otherwise, false.</returns>
    public bool IsSatisfiedBy(T candidate);
}
