// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.CitizenManagement.DTOs;
using Beagl.Application.CitizenManagement.Services;
using Beagl.Domain.Core.Exceptions;
using Beagl.WebApp.Constants;
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

        try
        {
            _ = await citizenService.CreateAsync(dto);
        }
        catch(DomainException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return Page();
        }

        return RedirectToPage(Redirection.ToCitizenList);
    }
}
