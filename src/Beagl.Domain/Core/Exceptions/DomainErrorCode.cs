// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.Core.Exceptions;

/// <summary>
/// Enumeration of domain error codes.
/// </summary>
public static class DomainErrorCode
{
    /// <summary>
    /// Unknown error.
    /// </summary>
    public const string Unknown = "Unknown";

    /// <summary>
    /// Invalid first name in PersonName value object.
    /// </summary>
    public const string PersonNameInvalidFirstName = "PersonNameInvalidFirstName";

    /// <summary>
    /// Invalid last name in PersonName value object.
    /// </summary>
    public const string PersonNameInvalidLastName = "PersonNameInvalidLastName";

    /// <summary>
    /// First name too long in PersonName value object.
    /// </summary>
    public const string PersonNameFirstNameTooLong = "PersonNameFirstNameTooLong";

    /// <summary>
    /// Last name too long in PersonName value object.
    /// </summary>
    public const string PersonNameLastNameTooLong = "PersonNameLastNameTooLong";

    /// <summary>
    /// Invalid phone number in PhoneNumber value object.
    /// </summary>
    public const string CitizenInvalidEmail = "CitizenInvalidEmail";

    /// <summary>
    /// Email must be provided when communication preference is Email.
    /// </summary>
    public const string CitizenEmailMustBeProvided = "CitizenEmailMustBeProvided";
    /// <summary>
    /// Cell phone must be provided when communication preference is CellPhone.
    /// </summary>
    public const string CitizenCellPhoneMustBeProvided = "CitizenCellPhoneMustBeProvided";
    /// <summary>
    /// Phone must be provided when communication preference is Phone.
    /// </summary>
    public const string CitizenPhoneMustBeProvided = "CitizenPhoneMustBeProvided";
    /// <summary>
    /// At least one phone number (phone or cell phone) must be provided.
    /// </summary>
    public const string CitizenAtLeastOnePhoneMustBeProvided = "CitizenAtLeastOnePhoneMustBeProvided";
    /// <summary>
    /// Invalid person name in Citizen entity.
    /// </summary>
    public const string CitizenInvalidPersonName = "CitizenInvalidPersonName";
    /// <summary>
    /// Invalid address in Citizen entity.
    /// </summary>
    public const string CitizenInvalidAddress = "CitizenInvalidAddress";
    /// <summary>
    /// Animal name cannot be null or whitespace.
    /// </summary>
    public const string AnimalNameCannotBeNullOrWhitespace = "AnimalNameCannotBeNullOrWhitespace";
    /// <summary>
    /// Primary breed ID cannot be empty.
    /// </summary>
    public const string AnimalPrimaryBreedIdCannotBeEmpty = "AnimalPrimaryBreedIdCannotBeEmpty";
    /// <summary>
    /// Color ID cannot be empty.
    /// </summary>
    public const string AnimalColorIdCannotBeEmpty = "AnimalColorIdCannotBeEmpty";
    /// <summary>
    /// Species type must be known.
    /// </summary>
    public const string AnimalSpeciesTypeMustBeKnown = "AnimalSpeciesTypeMustBeKnown";
    /// <summary>
    /// Date of birth must be specified.
    /// </summary>
    public const string AnimalDateOfBirthMustBeSpecified = "AnimalDateOfBirthMustBeSpecified";
    /// <summary>
    /// Date of birth cannot be in the future.
    /// </summary>
    public const string AnimalDateOfBirthCannotBeInTheFuture = "AnimalDateOfBirthCannotBeInTheFuture";

    /// <summary>
    /// Date of birth is unreasonably old.
    /// </summary>
    public const string AnimalDateOfBirthIsUnreasonablyOld = "AnimalDateOfBirthIsUnreasonablyOld";

    /// <summary>
    /// Color name cannot be null or whitespace.
    /// </summary>
    public const string ColorNameCannotBeNullOrWhitespace = "ColorNameCannotBeNullOrWhitespace";

    /// <summary>
    /// Breed name cannot be null or whitespace.
    /// </summary>
    public const string BreedNameCannotBeNullOrWhitespace = "BreedNameCannotBeNullOrWhitespace";

    /// <summary>
    /// Medal value cannot be null or empty.
    /// </summary>
    public const string AddressStreetAddressRequired = "AddressStreetAddressRequired";

    /// <summary>
    /// City cannot be null or whitespace.
    /// </summary>
    public const string AddressCityRequired = "AddressCityRequired";

    /// <summary>
    /// Province cannot be null or whitespace.
    /// </summary>
    public const string AddressProvinceRequired = "AddressProvinceRequired";

    /// <summary>
    /// Country cannot be null or whitespace.
    /// </summary>
    public const string AddressCountryRequired = "AddressCountryRequired";

    /// <summary>
    /// Postal code cannot be null or whitespace.
    /// </summary>
    public const string AddressPostalCodeRequired = "AddressPostalCodeRequired";

    /// <summary>
    /// Phone number cannot be null or empty.
    /// </summary>
    public const string PhoneCannotBeNullOrEmpty = "PhoneCannotBeNullOrEmpty";

    /// <summary>
    /// Phone number must not contain invalid characters.
    /// </summary>
    public const string PhoneMustNotContainInvalidCharacters = "PhoneMustNotContainInvalidCharacters";

    /// <summary>
    /// Phone number must be 10 or 11 digits.
    /// </summary>
    public const string PhoneMustBe10Or11Digits = "PhoneMustBe10Or11Digits";

    /// <summary>
    /// Medal value cannot be null or empty.
    /// </summary>
    public const string MedalValueCannotBeNullOrEmpty = "MedalValueCannotBeNullOrEmpty";

    /// <summary>
    /// Audit date is not valid.
    /// </summary>
    public const string AuditDateIsNotValid = "AuditDateIsNotValid";

    /// <summary>
    /// Audit date cannot be in the future.
    /// </summary>
    public const string AuditDateCannotBeInTheFuture = "AuditDateCannotBeInTheFuture";

    /// <summary>
    /// Audit date is unreasonably old.
    /// </summary>
    public const string AuditDateIsUnreasonablyOld = "AuditDateIsUnreasonablyOld";

    /// <summary>
    /// Weight must be positive.
    /// </summary>
    public const string WeightMustBePositive = "WeightMustBePositive";

    /// <summary>
    /// Vaccination date is required when vaccinated is true.
    /// </summary>
    public const string RabiesVaccinationDateRequired = "RabiesVaccinationDateRequired";

    /// <summary>
    /// The provided origin city information does not satisfy business rules.
    /// </summary>
    public const string OriginCityInfoInvalid = "OriginCityInfoInvalid";

    /// <summary>
    /// The microchip value is invalid.
    /// </summary>
    public const string MicrochipInvalidValue = "MicrochipInvalidValue";

    /// <summary>
    /// User not found.
    /// </summary>
    public const string UserNotFound = "UserNotFound";

    /// <summary>
    /// Cannot delete the last user.
    /// </summary>
    public const string UserCannotDeleteLastUser = "UserCannotDeleteLastUser";

    /// <summary>
    /// User data is invalid.
    /// </summary>
    public const string UserDataIsInvalid = "UserDataIsInvalid";

    /// <summary>
    /// User password is invalid.
    /// </summary>
    public const string UserPasswordIsInvalid = "UserPasswordIsInvalid";

    /// <summary>
    /// User roles data is invalid.
    /// </summary>
    public const string UserRolesDataIsInvalid = "UserRolesDataIsInvalid";

    /// <summary>
    /// At least one role must be specified for the user.
    /// </summary>
    public const string UserAtLeastOneRoleMustBeSpecified = "UserAtLeastOneRoleMustBeSpecified";

    /// <summary>
    /// User email is invalid.
    /// </summary>
    public const string UserEmailIsInvalid = "UserEmailIsInvalid";

    /// <summary>
    /// User email already exists.
    /// </summary>
    public const string UserEmailAlreadyExists = "UserEmailAlreadyExists";

    /// <summary>
    /// Username already exists.
    /// </summary>
    public const string UserNameAlreadyExists = "UserNameAlreadyExists";
}
