// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.Core.Exceptions;

/// <summary>
/// Enumeration of domain error codes.
/// </summary>
public enum DomainErrorCode
{
    /// <summary>
    /// Unknown error.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Invalid first name in PersonName value object.
    /// </summary>
    PersonNameInvalidFirstName = 101,

    /// <summary>
    /// Invalid last name in PersonName value object.
    /// </summary>
    PersonNameInvalidLastName = 102,

    /// <summary>
    /// First name too long in PersonName value object.
    /// </summary>
    PersonNameFirstNameTooLong = 104,

    /// <summary>
    /// Last name too long in PersonName value object.
    /// </summary>
    PersonNameLastNameTooLong = 103,

    /// <summary>
    /// Invalid phone number in PhoneNumber value object.
    /// </summary>
    CitizenInvalidEmail = 201,

    /// <summary>
    /// Email must be provided when communication preference is Email.
    /// </summary>
    CitizenEmailMustBeProvided = 202,

    /// <summary>
    /// Cell phone must be provided when communication preference is CellPhone.
    /// </summary>
    CitizenCellPhoneMustBeProvided = 203,

    /// <summary>
    /// Phone must be provided when communication preference is Phone.
    /// </summary>
    CitizenPhoneMustBeProvided = 204,

    /// <summary>
    /// At least one phone number (phone or cell phone) must be provided.
    /// </summary>
    CitizenAtLeastOnePhoneMustBeProvided = 205,

    /// <summary>
    /// Invalid person name in Citizen entity.
    /// </summary>
    CitizenInvalidPersonName = 206,

    /// <summary>
    /// Invalid address in Citizen entity.
    /// </summary>
    CitizenInvalidAddress = 207,

    /// <summary>
    /// Animal name cannot be null or whitespace.
    /// </summary>
    AnimalNameCannotBeNullOrWhitespace = 301,

    /// <summary>
    /// Primary breed ID cannot be empty.
    /// </summary>
    AnimalPrimaryBreedIdCannotBeEmpty = 302,

    /// <summary>
    /// Color ID cannot be empty.
    /// </summary>
    AnimalColorIdCannotBeEmpty = 303,

    /// <summary>
    /// Species type must be known.
    /// </summary>
    AnimalSpeciesTypeMustBeKnown = 304,

    /// <summary>
    /// Date of birth must be specified.
    /// </summary>
    AnimalDateOfBirthMustBeSpecified = 305,

    /// <summary>
    /// Date of birth cannot be in the future.
    /// </summary>
    AnimalDateOfBirthCannotBeInTheFuture = 306,

    /// <summary>
    /// Date of birth is unreasonably old.
    /// </summary>
    AnimalDateOfBirthIsUnreasonablyOld = 307,

    /// <summary>
    /// Color name cannot be null or whitespace.
    /// </summary>
    ColorNameCannotBeNullOrWhitespace = 401,

    /// <summary>
    /// Breed name cannot be null or whitespace.
    /// </summary>
    BreedNameCannotBeNullOrWhitespace = 501,

    /// <summary>
    /// Medal value cannot be null or empty.
    /// </summary>
    AddressStreetAddressRequired = 601,

    /// <summary>
    /// City cannot be null or whitespace.
    /// </summary>
    AddressCityRequired = 602,

    /// <summary>
    /// Province cannot be null or whitespace.
    /// </summary>
    AddressProvinceRequired = 603,

    /// <summary>
    /// Country cannot be null or whitespace.
    /// </summary>
    AddressCountryRequired = 604,

    /// <summary>
    /// Postal code cannot be null or whitespace.
    /// </summary>
    AddressPostalCodeRequired = 605,

    /// <summary>
    /// Phone number cannot be null or empty.
    /// </summary>
    PhoneCannotBeNullOrEmpty = 701,

    /// <summary>
    /// Phone number must not contain invalid characters.
    /// </summary>
    PhoneMustNotContainInvalidCharacters = 702,

    /// <summary>
    /// Phone number must be 10 or 11 digits.
    /// </summary>
    PhoneMustBe10Or11Digits = 703,

    /// <summary>
    /// Medal value cannot be null or empty.
    /// </summary>
    MedalValueCannotBeNullOrEmpty = 801,

    /// <summary>
    /// Audit date is not valid.
    /// </summary>
    AuditDateIsNotValid = 901,

    /// <summary>
    /// Audit date cannot be in the future.
    /// </summary>
    AuditDateCannotBeInTheFuture = 902,

    /// <summary>
    /// Audit date is unreasonably old.
    /// </summary>
    AuditDateIsUnreasonablyOld = 903,

    /// <summary>
    /// Weight must be positive.
    /// </summary>
    WeightMustBePositive = 1001,

    /// <summary>
    /// Vaccination date is required when vaccinated is true.
    /// </summary>
    RabiesVaccinationDateRequired = 1101,

    /// <summary>
    /// The provided origin city information does not satisfy business rules.
    /// </summary>
    OriginCityInfoInvalid = 1201,

    /// <summary>
    /// The microchip value is invalid.
    /// </summary>
    MicrochipInvalidValue = 1301,

    /// <summary>
    /// User not found.
    /// </summary>
    UserNotFound = 1401,

    /// <summary>
    /// Cannot delete the last user.
    /// </summary>
    UserCannotDeleteLastUser = 1402
}
