// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.Core;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Domain.CitizenManagement.Entities;

/// <summary>
/// Represents a postal address for a citizen, including metadata for ordering.
/// </summary>
public sealed class Address : Entity
{
    /// <summary>
    /// Gets or sets the street number.
    /// </summary>
    public string StreetNumber { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the street name.
    /// </summary>
    public string StreetName { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the apartment number.
    /// </summary>
    public string? Appartment { get; private set; }

    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    public string City { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the province.
    /// </summary>
    public string Province { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the country.
    /// </summary>
    public string Country { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the postal code.
    /// </summary>
    public string PostalCode { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the post office box.
    /// </summary>
    public string? PostOfficeBox { get; private set; }

    /// <summary>
    /// Gets or sets the date the address was added (used for ordering).
    /// </summary>
    public Audit<Guid> Created { get; private set; } = default!;

    /// <summary>
    /// Gets or sets the citizen id (foreign key).
    /// </summary>
    public Guid CitizenId { get; private set; }

    /// <summary>
    /// Navigation property to the owning citizen.
    /// </summary>
    public Citizen? Citizen { get; private set; }

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
        string? postOfficeBox,
        Audit<Guid> created)
    {
        Id = Guid.NewGuid();
        StreetNumber = streetNumber;
        StreetName = streetName;
        Appartment = appartment;
        City = city;
        Province = province;
        Country = country;
        PostalCode = postalCode;
        PostOfficeBox = postOfficeBox;
        Created = created;
    }
}
