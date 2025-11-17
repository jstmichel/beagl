// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Collections.Generic;
using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.CitizenManagement.Enums;
using Beagl.Domain.Core;
using Beagl.Domain.Core.ValueObjects;
using Beagl.Domain.CitizenManagement.ValueObjects;
using Beagl.Domain.Core.Exceptions;

namespace Beagl.Domain.CitizenManagement.Entities;

/// <summary>
/// Persistence model for Citizen aggregate.
/// </summary>
public sealed class Citizen : AuditedAggregateRoot
{
    /// <summary>
    /// Gets or sets the name of the citizen.
    /// </summary>
    public PersonName Person { get; private set; } = default!;

    /// <summary>
    /// Gets or sets the phone number.
    /// </summary>
    public PhoneNumber? Phone { get; private set; }

    /// <summary>
    /// Gets or sets the cell phone number.
    /// </summary>
    public PhoneNumber? CellPhone { get; private set; }

    /// <summary>
    /// Gets or sets the communication preference (Phone, CellPhone, Email).
    /// </summary>
    public CommunicationPreference CommunicationPreference { get; private set; } = CommunicationPreference.None;

    /// <summary>
    /// Gets or sets the language preference (fr, en).
    /// </summary>
    public LanguagePreference LanguagePreference { get; private set; } = LanguagePreference.None;

    /// <summary>
    /// Gets or sets the email address.
    /// </summary>
    public string? Email { get; private set; }


    /// <summary>
    /// Gets the address associated with the citizen.
    /// </summary>
    public Address Address { get; private set; } = default!;

    /// <summary>
    /// Gets the list of animals owned by the citizen.
    /// </summary>
    public ICollection<Animal> Animals { get; } = [];

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
        PhoneNumber? phone,
        PhoneNumber? cellPhone,
        CommunicationPreference communicationPreference,
        LanguagePreference languagePreference,
        string? email,
        Address address,
        Audit<Guid> created)
        : base(created)
    {
        ValidatePersonName(person);
        ValidateAddress(address);
        ValidateAtLeastOnePhoneIsProvided(phone, cellPhone);
        ValidateCommunicationPreference(communicationPreference, phone, cellPhone, email);
        ValidateEmail(email);

        Person = person;
        Phone = phone;
        CellPhone = cellPhone;
        CommunicationPreference = communicationPreference;
        LanguagePreference = languagePreference;
        Email = email;
        Address = address;
    }

    private static void ValidateEmail(string? email)
    {
        if (!string.IsNullOrWhiteSpace(email) && !IsValidEmail(email))
        {
            throw new InvalidCitizenException($"The email address '{email}' is not in a valid format.");
        }
    }

    private static void ValidateCommunicationPreference(
        CommunicationPreference communicationPreference,
        PhoneNumber? phone,
        PhoneNumber? cellPhone,
        string? email)
    {
        switch (communicationPreference)
        {
            case CommunicationPreference.Phone:
                ValidatePhoneIsProvided(phone);
                break;
            case CommunicationPreference.CellPhone:
                ValidateCellPhoneIsProvided(cellPhone);
                break;
            case CommunicationPreference.Email:
                ValidateEmailIsProvided(email);
                break;
        }
    }

    private static void ValidateEmailIsProvided(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new InvalidCitizenException("Communication preference is set to Email, but no email address is provided.");
        }
    }

    private static void ValidateCellPhoneIsProvided(PhoneNumber? cellPhone)
    {
        if (cellPhone == null)
        {
            throw new InvalidCitizenException("Communication preference is set to CellPhone, but no cell phone number is provided.");
        }
    }

    private static void ValidatePhoneIsProvided(PhoneNumber? phone)
    {
        if (phone == null)
        {
            throw new InvalidCitizenException("Communication preference is set to Phone, but no phone number is provided.");
        }
    }

    private static void ValidateAtLeastOnePhoneIsProvided(PhoneNumber? phone, PhoneNumber? cellPhone)
    {
        if (phone == null && cellPhone == null)
        {
            throw new InvalidCitizenException("At least one phone number (phone or cell phone) must be provided.");
        }
    }

    private static void ValidatePersonName(PersonName person)
    {
        if (person == null)
        {
            throw new InvalidCitizenException("Person name cannot be null.");
        }
    }

    private static void ValidateAddress(Address address)
    {
        if (address == null)
        {
            throw new InvalidCitizenException("Address cannot be null.");
        }
    }

    private static bool IsValidEmail(string email)
    {
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    }
}
