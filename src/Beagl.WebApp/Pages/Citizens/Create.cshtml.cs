using Beagl.Application.CitizenManagement.DTOs;
using Beagl.Application.CitizenManagement.Services;
using Beagl.WebApp.Constants;
using Beagl.WebApp.Pages.Citizens.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beagl.WebApp.Pages.Citizens;

/// <summary>
/// Page model for creating a new citizen.
/// </summary>
internal sealed class CreateCitizenModel(
    ICitizenService citizenService) : PageModel
{
    /// <summary>
    /// Gets or sets the input model for creating a citizen.
    /// </summary>
    [BindProperty]
    public CreateCitizenViewModel Input { get; set; } = new CreateCitizenViewModel();

    public IActionResult OnGet() => Page();

    public IActionResult OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        CreateCitizenDto createCitizenDto = MapToDto();

        _ = citizenService.CreateAsync(createCitizenDto);

        return RedirectToPage(LocalRedirection.Citizens);
    }

    private CreateCitizenDto MapToDto()
    {
        return new()
        {
            Civility = Input.Civility,
            FirstName = Input.FirstName!,
            LastName = Input.LastName!,
            Phone = Input.Phone,
            CellPhone = Input.CellPhone,
            CommunicationPreference = Input.CommunicationPreference,
            LanguagePreference = Input.LanguagePreference,
            Email = Input.Email,
            StreetNumber = Input.StreetNumber!,
            StreetName = Input.StreetName!,
            Appartment = Input.Appartment,
            City = Input.City!,
            Province = Input.Province!,
            PostalCode = Input.PostalCode!,
            Country = Input.Country!,
            PostOfficeBox = Input.PostOfficeBox!,
        };
    }
}
