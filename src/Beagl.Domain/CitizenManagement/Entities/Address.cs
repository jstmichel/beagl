// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.CitizenManagement.Entities;

/// <summary>
/// Represents a postal address for a citizen, including metadata for ordering.
/// </summary>
public sealed class Address
{
    /// <summary>
    /// Gets or sets the unique identifier for the address.
    /// </summary>
    public Guid AddressId { get; set; }

    /// <summary>
    /// Gets or sets the street number.
    /// </summary>
    public string StreetNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the street name.
    /// </summary>
    public string StreetName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the apartment number.
    /// </summary>
    public string? Appartment { get; set; }

    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the province.
    /// </summary>
    public string Province { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the country.
    /// </summary>
    public string Country { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the postal code.
    /// </summary>
    public string PostalCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the post office box.
    /// </summary>
    public string? PostOfficeBox { get; set; }

    /// <summary>
    /// Gets or sets the date the address was added (used for ordering).
    /// </summary>
    public DateTime AddedDate { get; set; } = DateTime.UtcNow.ToUniversalTime();

    /// <summary>
    /// Gets or sets the citizen id (foreign key).
    /// </summary>
    public Guid CitizenId { get; set; }

    /// <summary>
    /// Navigation property to the owning citizen.
    /// </summary>
    public Citizen? Citizen { get; set; }

    /// <summary>
    /// Parameterless constructor for EF Core.
    /// </summary>
    private Address() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Address"/> class.
    /// </summary>
    public Address(
        string streetNumber,
        string streetName,
        string? appartment,
        string city,
        string province,
        string country,
        string postalCode,
        string? postOfficeBox)
    {
        AddressId = Guid.NewGuid();
        StreetNumber = streetNumber;
        StreetName = streetName;
        Appartment = appartment;
        City = city;
        Province = province;
        Country = country;
        PostalCode = postalCode;
        PostOfficeBox = postOfficeBox;
        AddedDate = DateTime.UtcNow.ToUniversalTime();
    }
}
