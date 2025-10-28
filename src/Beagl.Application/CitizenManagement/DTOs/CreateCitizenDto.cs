// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Application.CitizenManagement.DTOs;

/// <summary>
/// Data transfer object for creating a new citizen.
/// </summary>
public class CreateCitizenDto
{
    /// <summary>
	/// Civility (e.g., Mr., Mrs., Ms., etc.)
	/// </summary>
	public string? Civility { get; set; }

	/// <summary>
	/// First name of the citizen.
	/// </summary>
	public string? FirstName { get; set; }

	/// <summary>
	/// Last name of the citizen.
	/// </summary>
	public string? LastName { get; set; }

	/// <summary>
	/// Phone number.
	/// </summary>
	public string? Phone { get; set; }

    /// <summary>
    /// Cell phone number.
    /// </summary>
    public string? CellPhone { get; set; }

	/// <summary>
	/// Communication preference (Phone, CellPhone, Email).
	/// </summary>
    public string? CommunicationPreference { get; set; }

	/// <summary>
	/// Language preference (fr, en).
	/// </summary>
    public string? LanguagePreference { get; set; }

	/// <summary>
	/// Email address.
	/// </summary>
	public string? Email { get; set; }

    /// <summary>
	/// Street number.
	/// </summary>
    public string? StreetNumber { get; set; }

	/// <summary>
	/// Street name.
	/// </summary>
	public string? StreetName { get; set; }

	/// <summary>
	/// Apartment number.
	/// </summary>
    public string? Appartment { get; set; }

	/// <summary>
	/// City.
	/// </summary>
    public string? City { get; set; }

	/// <summary>
	/// Province.
	/// </summary>
    public string? Province { get; set; }

	/// <summary>
	/// Country.
	/// </summary>
    public string? Country { get; set; }

	/// <summary>
	/// Postal code.
	/// </summary>
	public string? PostalCode { get; set; }

	/// <summary>
	/// Post office box.
	/// </summary>
	public string? PostOfficeBox { get; set; }
}
