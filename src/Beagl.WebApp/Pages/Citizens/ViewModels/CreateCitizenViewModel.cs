// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.WebApp.Pages.Citizens.ViewModels;

using System.ComponentModel.DataAnnotations;
using Beagl.WebApp.Resources.Pages.Citizens;

/// <summary>
/// View model for creating a new citizen.
/// </summary>
public class CreateCitizenViewModel
{
	/// <summary>
	/// Civility (e.g., Mr., Mrs., Ms., etc.)
	/// </summary>
	[Display(Name = "Civility")]
	public int Civility { get; set; }

	/// <summary>
	/// First name of the citizen.
	/// </summary>
	[Required(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "FirstName_Required")]
	[Display(Name = "First Name")]
	public string? FirstName { get; set; }

	/// <summary>
	/// Last name of the citizen.
	/// </summary>
	[Required(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "LastName_Required")]
	[Display(Name = "Last Name")]
	public string? LastName { get; set; }

	/// <summary>
	/// Phone number.
	/// </summary>
    [Phone(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "PhoneFormat_Invalid")]
	[Display(Name = "Phone Number")]
	public string? Phone { get; set; }

    /// <summary>
    /// Cell phone number.
    /// </summary>
    [Phone(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "CellPhoneFormat_Invalid")]
    [Display(Name = "Cell Phone")]
    public string? CellPhone { get; set; }

	/// <summary>
	/// Communication preference (Phone, CellPhone, Email).
	/// </summary>
	[Required(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "CommunicationPreference_Required")]
	[Display(Name = "Communication Preference")]
    public int CommunicationPreference { get; set; }

	/// <summary>
	/// Language preference (fr, en).
	/// </summary>
	[Required(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "LanguagePreference_Required")]
	[Display(Name = "Language Preference")]
    public int LanguagePreference { get; set; }

	/// <summary>
	/// Email address.
	/// </summary>
	[EmailAddress(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "Email_Required")]
	[Display(Name = "Email")]
	public string? Email { get; set; }

    /// <summary>
	/// Street number.
	/// </summary>
	[Required(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "StreetAddress_Required")]
	[Display(Name = "Street Address")]
    public string StreetAddress { get; set; } = string.Empty;

	/// <summary>
	/// City.
	/// </summary>
	[Required(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "City_Required")]
	[Display(Name = "City")]
    public string? City { get; set; }

	/// <summary>
	/// Province.
	/// </summary>
	[Required(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "Province_Required")]
	[Display(Name = "Province")]
    public string? Province { get; set; }

	/// <summary>
	/// Country.
	/// </summary>
	[Required(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "Country_Required")]
	[Display(Name = "Country")]
    public string? Country { get; set; }

	/// <summary>
	/// Postal code.
	/// </summary>
	[Required(ErrorMessageResourceType = typeof(Create), ErrorMessageResourceName = "PostalCode_Required")]
	[Display(Name = "Postal Code")]
	public string? PostalCode { get; set; }

	/// <summary>
	/// Post office box.
	/// </summary>
	[Display(Name = "PostOfficeBox")]
	public string? PostOfficeBox { get; set; }
}
