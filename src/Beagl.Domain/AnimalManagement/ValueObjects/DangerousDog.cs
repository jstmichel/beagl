// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents the dangerous dog status as a value object.
/// </summary>
public class DangerousDog
{
    /// <summary>
    /// Gets a value indicating whether the dog is considered dangerous.
    /// </summary>
    public bool IsDangerous { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the dog has responsibility insurance.
    /// </summary>
    public bool HasResponsibilityInsurance { get; private set; }

    /// <summary>
    /// Gets an optional comment about the dangerous dog status.
    /// </summary>
    public string? Comment { get; private set; }

    private DangerousDog(bool isDangerous, bool hasResponsibilityInsurance, string? comment)
    {
        IsDangerous = isDangerous;
        HasResponsibilityInsurance = hasResponsibilityInsurance;
        Comment = comment;
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
