using Beagl.Application.CitizenManagement.DTOs;
using Beagl.Application.CitizenManagement.Services;
using Beagl.WebApp.Constants;
using Beagl.WebApp.Mappers;
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

        CreateCitizenDto createCitizenDto = Input.ToDto();
        _ = citizenService.CreateAsync(createCitizenDto);

        return RedirectToPage(LocalRedirection.Citizens);
    }
}
