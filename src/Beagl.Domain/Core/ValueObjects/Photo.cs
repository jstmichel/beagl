// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.Core.ValueObjects;

/// <summary>
/// Represents a photo for an animal, stored as a base64-encoded PNG image.
/// </summary>
public sealed class Photo : IEquatable<Photo>
{
    /// <summary>
    /// Gets the base64-encoded PNG image string.
    /// </summary>
	public string Base64Png { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Photo"/> class.
    /// </summary>
    /// <param name="base64Png">The base64-encoded PNG image string.</param>
    public Photo(string base64Png)
    {
        ArgumentException.ThrowIfNullOrEmpty(base64Png, nameof(base64Png));

        Base64Png = base64Png;
    }

    /// <inheritdoc/>
    public bool Equals(Photo? other) => other is not null && Base64Png == other.Base64Png;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as Photo);

    /// <inheritdoc/>
    public override int GetHashCode() => Base64Png.GetHashCode(StringComparison.Ordinal);

    /// <summary>
    /// Equality operator for Photo value objects.
    /// </summary>
    /// <param name="left">The left Photo value.</param>
    /// <param name="right">The right Photo value.</param>
    /// <returns>True if both Photo values are equal; otherwise, false.</returns>
    public static bool operator ==(Photo left, Photo right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Inequality operator for Photo value objects.
    /// </summary>
    /// <param name="left">The left Photo value.</param>
    /// <param name="right">The right Photo value.</param>
    /// <returns>True if both Photo values are not equal; otherwise, false.</returns>
    public static bool operator !=(Photo left, Photo right)
    {
        return !Equals(left, right);
    }

    /// <summary>
    /// Creates a Photo value object from the given base64-encoded PNG string.
    /// </summary>
    /// <param name="base64Png">The base64-encoded PNG image string.</param>
    /// <returns>A Photo value object or null if the input is invalid.</returns>
    public static Photo? From(string? base64Png)
    {
        if (string.IsNullOrWhiteSpace(base64Png))
        {
            return null;
        }

        return new Photo(base64Png);
    }
}
