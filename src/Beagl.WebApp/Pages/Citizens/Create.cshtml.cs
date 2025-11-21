// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.CitizenManagement.DTOs;
using Beagl.Application.CitizenManagement.Services;
using Beagl.Application.Core.Helpers;
using Beagl.WebApp.Constants;
using Beagl.WebApp.Extensions;
using Beagl.WebApp.Mappers;
using Beagl.WebApp.Pages.Citizens.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beagl.WebApp.Pages.Citizens;

/// <summary>
/// Page model for creating a new citizen.
/// </summary>
[Authorize(Policy = Policies.Citizens.CanCreate)]
internal sealed class CreateCitizenModel(
    ICitizenService citizenService) : PageModel
{
    /// <summary>
    /// Gets or sets the input model for creating a citizen.
    /// </summary>
    [BindProperty]
    public CreateCitizenViewModel Input { get; set; } = new CreateCitizenViewModel();

    public IActionResult OnGet() => Page();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        CreateCitizenDto dto = Input.ToDto();
        Result<Guid> result = await citizenService.CreateAsync(dto);

        if (!result.Success)
        {
            ModelState.AddResultErrors(result);
            return Page();
        }

        return RedirectToPage(Redirection.ToCitizenList);
    }
}
