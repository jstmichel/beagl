// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents the dangerous dog status as a value object.
/// </summary>
public sealed class DangerousDog : IEquatable<DangerousDog>
{
    /// <summary>
    /// Gets a value indicating whether the dog is considered dangerous.
    /// </summary>
    public bool IsDangerous { get; }

    /// <summary>
    /// Gets a value indicating whether the dog has responsibility insurance.
    /// </summary>
    public bool HasResponsibilityInsurance { get; }

    /// <summary>
    /// Gets an optional comment about the dangerous dog status.
    /// </summary>
    public string? Comment { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DangerousDog"/> class.
    /// </summary>
    /// <param name="isDangerous">Indicates if the dog is considered dangerous.</param>
    /// <param name="hasResponsibilityInsurance">Indicates if the dog has responsibility insurance.</param>
    /// <param name="comment">An optional comment about the dangerous dog status.</param>
    public DangerousDog(bool isDangerous, bool hasResponsibilityInsurance, string? comment)
    {
        IsDangerous = isDangerous;
        HasResponsibilityInsurance = hasResponsibilityInsurance;
        Comment = comment;
    }

    /// <inheritdoc/>
    public bool Equals(DangerousDog? other)
    {
        if (other is null)
            return false;

        return IsDangerous == other.IsDangerous &&
               HasResponsibilityInsurance == other.HasResponsibilityInsurance &&
               Comment == other.Comment;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as DangerousDog);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(
        IsDangerous,
        HasResponsibilityInsurance,
        Comment);

    /// <summary>
    /// Equality operator for DangerousDog.
    /// </summary>
    public static bool operator ==(DangerousDog? left, DangerousDog? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Inequality operator for DangerousDog.
    /// </summary>
    public static bool operator !=(DangerousDog? left, DangerousDog? right)
    {
        return !Equals(left, right);
    }

    /// <summary>
    /// Creates a DangerousDog value object from the given parameters.
    /// </summary>
    /// <param name="isDangerous">Indicates if the dog is considered dangerous.</param>
    /// <param name="hasResponsibilityInsurance">Indicates if the dog has responsibility insurance.</param>
    /// <param name="comment">An optional comment about the dangerous dog status.</param>
    /// <returns>A DangerousDog value object or null if any required input is invalid.</returns>
    public static DangerousDog? From(bool? isDangerous, bool? hasResponsibilityInsurance, string? comment = null)
    {
        if (isDangerous is null || hasResponsibilityInsurance is null)
            return null;
        return new DangerousDog(isDangerous.Value, hasResponsibilityInsurance.Value, string.IsNullOrWhiteSpace(comment) ? null : comment);
    }
}
