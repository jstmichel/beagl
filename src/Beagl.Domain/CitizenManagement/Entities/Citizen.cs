// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Collections.Generic;
using Beagl.Domain.CitizenManagement.ValueObjects;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Domain.CitizenManagement.Entities;

/// <summary>
/// Persistence model for Citizen aggregate.
/// </summary>
public class Citizen
{
    /// <summary>
    /// Private parameterless constructor for EF Core.
    /// </summary>
    private Citizen() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Citizen"/> class.
    /// </summary>
    /// <param name="person">The name of the citizen.</param>
    /// <param name="phone">The phone number.</param>
    /// <param name="cellPhone">The cell phone number.</param>
    /// <param name="communicationPreference">The communication preference.</param>
    /// <param name="languagePreference">The language preference.</param>
    /// <param name="email">The email address.</param>
    /// <param name="address">The address.</param>
    /// <param name="created">The audit information for creation.</param>
    public Citizen(
        PersonName person,
        string? phone,
        string? cellPhone,
        CommunicationPreference communicationPreference,
        LanguagePreference languagePreference,
        string? email,
        Address address,
        Audit<Guid> created)
    {
        Id = Guid.NewGuid();
        Person = person;
        Phone = phone;
        CellPhone = cellPhone;
        CommunicationPreference = communicationPreference;
        LanguagePreference = languagePreference;
        Email = email;
        Addresses = [address];
        Created = created;
    }

    /// <summary>
    /// Gets or sets the unique identifier for the citizen.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the citizen.
    /// </summary>
    public PersonName Person { get; set; } = default!;

    /// <summary>
    /// Gets or sets the phone number.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Gets or sets the cell phone number.
    /// </summary>
    public string? CellPhone { get; set; }

    /// <summary>
    /// Gets or sets the communication preference (Phone, CellPhone, Email).
    /// </summary>
    public CommunicationPreference CommunicationPreference { get; set; } = CommunicationPreference.None;

    /// <summary>
    /// Gets or sets the language preference (fr, en).
    /// </summary>
    public LanguagePreference LanguagePreference { get; set; } = LanguagePreference.None;

    /// <summary>
    /// Gets or sets the email address.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets the list of addresses associated with the citizen.
    /// </summary>
    public ICollection<Address> Addresses { get; } = [];

    /// <summary>
    /// Gets the audit information for creation.
    /// </summary>
    public Audit<Guid> Created { get; set; } = new Audit<Guid>(Guid.Empty, DateTimeOffset.MinValue);

    /// <summary>
    /// Gets the audit information for last modification.
    /// </summary>
    public Audit<Guid>? Modified { get; set; } = new Audit<Guid>(Guid.Empty, DateTimeOffset.MinValue);
}
