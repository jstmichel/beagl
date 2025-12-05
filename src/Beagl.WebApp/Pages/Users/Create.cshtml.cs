// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.Core.Helpers;
using Beagl.Application.UserManagement.DTOs;
using Beagl.Application.UserManagement.ViewModels;
using Beagl.Infrastructure.Core.Helpers;
using Beagl.Infrastructure.UserManagement.Interfaces;
using Beagl.WebApp.Constants;
using Beagl.WebApp.Extensions;
using Beagl.WebApp.Mappers;
using Beagl.WebApp.Pages.Users.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beagl.WebApp.Pages.Users;

/// <summary>
/// Page model for creating a new user.
/// </summary>
[Authorize(Policy = Policies.Users.CanCreate)]
internal sealed class CreateModel(
    IUserService userService,
    IRoleService roleService) : PageModel
{
    /// <summary>
    /// Gets or sets the new user to be created.
    /// </summary>
    [BindProperty]
    public CreateUserViewModel Input { get; set; } = new CreateUserViewModel();

    /// <summary>
    /// Gets or sets the available roles for selection.
    /// </summary>
    public List<RoleViewModel> AvailableRoles { get; set; } = [];

    /// <summary>
    /// Handles GET requests to initialize the page.
    /// </summary>
    public void OnGet()
    {
        AvailableRoles = GetAvailableRoles();
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            AvailableRoles = GetAvailableRoles();
            return Page();
        }

        UserDto dto = Input.ToDto();
        OperationResult result = await userService.CreateAsync(dto, Input.Password);
        if (!result.Success)
        {
            ModelState.AddResultErrors(result);
            AvailableRoles = GetAvailableRoles();
            return Page();
        }

        return RedirectToPage(Redirection.ToUserList);
    }

    private List<RoleViewModel> GetAvailableRoles()
    {
        IList<RoleDto> roles = roleService.GetAllRoles();
        List<RoleViewModel> items = [.. roles.Select(role => new RoleViewModel
        {
            Name = role.Name
        })];

        return items;
    }
}
