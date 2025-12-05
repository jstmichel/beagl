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
	public int Civility { get; set; } = default!;

	/// <summary>
	/// First name of the citizen.
	/// </summary>
	public string FirstName { get; set; } = default!;

	/// <summary>
	/// Last name of the citizen.
	/// </summary>
	public string LastName { get; set; } = default!;

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
    public int CommunicationPreference { get; set; } = default!;

	/// <summary>
	/// Language preference (fr, en).
	/// </summary>
    public int LanguagePreference { get; set; } = default!;

	/// <summary>
	/// Email address.
	/// </summary>
	public string? Email { get; set; }

    /// <summary>
	/// Street address.
	/// </summary>
    public string StreetAddress { get; set; } = default!;

	/// <summary>
	/// City.
	/// </summary>
    public string City { get; set; } = default!;

	/// <summary>
	/// Province.
	/// </summary>
    public string Province { get; set; } = default!;

	/// <summary>
	/// Country.
	/// </summary>
    public string Country { get; set; } = default!;

	/// <summary>
	/// Postal code.
	/// </summary>
	public string PostalCode { get; set; } = default!;

	/// <summary>
	/// Post office box.
	/// </summary>
	public string? PostOfficeBox { get; set; }
}
