using Beagl.WebApp.Constants;
using Beagl.WebApp.Pages.Citizens.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beagl.WebApp.Pages.Citizens;

/// <summary>
/// Page model for creating a new citizen.
/// </summary>
internal sealed class CreateCitizenModel : PageModel
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

        // _ = await catService.CreateCatAsync(new CreateCatDto
        // {
        //     Name = Input.Name,
        //     BreedPrimaryId = Input.BreedPrimaryId!.Value,
        //     ColorId = Input.ColorId!.Value,
        //     Description = Input.Description,
        //     Gender = Input.Gender,
        //     BirthDate = Input.BirthDate!.Value,
        //     PhotoBase64 = Input.PhotoBase64,
        //     MicrochipNumber = Input.MicrochipNumber,
        //     IsAnUnclawnedCat = Input.IsAnUnclawnedCat,
        //     Weight = Input.Weight,
        //     WeightUnit = Input.WeightUnit,
        // });

        return RedirectToPage(LocalRedirection.Citizens);
    }
}
