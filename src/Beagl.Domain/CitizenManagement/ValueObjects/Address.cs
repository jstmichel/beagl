// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Collections.Generic;

namespace Beagl.Domain.CitizenManagement.ValueObjects;

/// <summary>
/// Value object representing a postal address for a citizen.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="Address"/> value object.
/// </remarks>
/// <param name="streetAddress">The street address.</param>
/// <param name="city">The city.</param>
/// <param name="province">The province.</param>
/// <param name="country">The country.</param>
/// <param name="postalCode">The postal code.</param>
/// <param name="postOfficeBox">The post office box (optional).</param>
public sealed class Address(
    string streetAddress,
    string city,
    string province,
    string country,
    string postalCode,
    string? postOfficeBox)
{
    /// <summary>
    /// Gets the street address (number, street, apartment/unit).
    /// </summary>
    public string StreetAddress { get; } = streetAddress;

    /// <summary>
    /// Gets the city.
    /// </summary>
    public string City { get; } = city;

    /// <summary>
    /// Gets the province.
    /// </summary>
    public string Province { get; } = province;

    /// <summary>
    /// Gets the country.
    /// </summary>
    public string Country { get; } = country;

    /// <summary>
    /// Gets the postal code.
    /// </summary>
    public string PostalCode { get; } = postalCode;

    /// <summary>
    /// Gets the post office box (optional).
    /// </summary>
    public string? PostOfficeBox { get; } = postOfficeBox;

    /// <summary>
    /// Returns the address as a formatted string suitable for display.
    /// </summary>
    /// <returns>A formatted address string.</returns>
    public string ToDisplayString()
    {
        string line1 = StreetAddress;
        string line2 = $"{City}, {Province} {PostalCode}";
        string country = Country;
        string? poBox = string.IsNullOrWhiteSpace(PostOfficeBox) ? null : $"P.O. Box {PostOfficeBox}";

        List<string> parts = [];
        if (!string.IsNullOrWhiteSpace(poBox)) parts.Add(poBox);
        parts.Add(line1);
        parts.Add(line2);
        parts.Add(country);

        return string.Join("\n", parts);
    }
}
