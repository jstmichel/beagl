// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Collections.Generic;

namespace Beagl.Domain.CitizenManagement.ValueObjects;

/// <summary>
/// Value object representing a postal address for a citizen.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="Address"/> value object.
/// </remarks>
public sealed class Address : IEquatable<Address>
{
    /// <summary>
    /// Gets the street address (number, street, apartment/unit).
    /// </summary>
    public string StreetAddress { get; }

    /// <summary>
    /// Gets the city.
    /// </summary>
    public string City { get; }

    /// <summary>
    /// Gets the province.
    /// </summary>
    public string Province { get; }


    /// <summary>
    /// Gets the country.
    /// </summary>
    public string Country { get; }

    /// <summary>
    /// Gets the postal code.
    /// </summary>
    public string PostalCode { get; }

    /// <summary>
    /// Gets the post office box (optional).
    /// </summary>
    public string? PostOfficeBox { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Address"/> class.
    /// </summary>
    /// <param name="streetAddress">The street address (number, street, apartment/unit).</param>
    /// <param name="city">The city.</param>
    /// <param name="province">The province.</param>
    /// <param name="country">The country.</param>
    /// <param name="postalCode">The postal code.</param>
    /// <param name="postOfficeBox">The post office box (optional).</param>
    /// <exception cref="ArgumentNullException">Thrown when any required parameter is null or empty.</exception>
    public Address(
        string streetAddress,
        string city,
        string province,
        string country,
        string postalCode,
        string? postOfficeBox = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(streetAddress, nameof(streetAddress));
        ArgumentException.ThrowIfNullOrEmpty(city, nameof(city));
        ArgumentException.ThrowIfNullOrEmpty(province, nameof(province));
        ArgumentException.ThrowIfNullOrEmpty(country, nameof(country));
        ArgumentException.ThrowIfNullOrEmpty(postalCode, nameof(postalCode));

        StreetAddress = streetAddress;
        City = city;
        Province = province;
        Country = country;
        PostalCode = postalCode;
        PostOfficeBox = postOfficeBox;
    }

    /// <inheritdoc/>
    public bool Equals(Address? other)
    {
        if (other is null)
            return false;

        return StreetAddress == other.StreetAddress &&
               City == other.City &&
               Province == other.Province &&
               Country == other.Country &&
               PostalCode == other.PostalCode &&
               PostOfficeBox == other.PostOfficeBox;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as Address);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(
        StreetAddress,
        City,
        Province,
        Country,
        PostalCode,
        PostOfficeBox);

    /// <summary>
    /// Equality operator for Address.
    /// </summary>
    public static bool operator ==(Address? left, Address? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Inequality operator for Address.
    /// </summary>
    public static bool operator !=(Address? left, Address? right)
    {
        return !Equals(left, right);
    }

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

    /// <summary>
    /// Creates an Address value object from the given parameters.
    /// </summary>
    /// <param name="streetAddress">The street address (number, street, apartment/unit).</param>
    /// <param name="city">The city.</param>
    /// <param name="province">The province.</param>
    /// <param name="country">The country.</param>
    /// <param name="postalCode">The postal code.</param>
    /// <param name="postOfficeBox">The post office box (optional).</param>
    /// <returns>An Address value object or null if any required input is invalid.</returns>
    public static Address? From(
        string streetAddress,
        string city,
        string province,
        string country,
        string postalCode,
        string? postOfficeBox = null)
    {
        if (string.IsNullOrWhiteSpace(streetAddress) ||
            string.IsNullOrWhiteSpace(city) ||
            string.IsNullOrWhiteSpace(province) ||
            string.IsNullOrWhiteSpace(country) ||
            string.IsNullOrWhiteSpace(postalCode))
        {
            return null;
        }

        return new Address(
            streetAddress,
            city,
            province,
            country,
            postalCode,
            postOfficeBox);
    }
}
