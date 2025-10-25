// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.Core.ValueObjects;

/// <summary>
/// Represents a photo for an animal, stored as a base64-encoded PNG image.
/// </summary>
public class Photo
{
    /// <summary>
    /// Gets the base64-encoded PNG image string.
    /// </summary>
	public string Base64Png { get; private set; }

    private Photo(string base64Png) => Base64Png = base64Png;

    /// <summary>
    /// Creates a Photo value object from the given base64-encoded PNG string.
    /// </summary>
    /// <param name="base64Png">The base64-encoded PNG image string.</param>
    /// <returns>A Photo value object or null if the input is invalid.</returns>
    public static Photo? From(string? base64Png)
    {
        if (string.IsNullOrWhiteSpace(base64Png))
            return null;
        // Optionally: validate base64 format
        return new Photo(base64Png);
    }
}
