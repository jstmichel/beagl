// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Collections.ObjectModel;
using Beagl.Domain.Exceptions.Entities;
using Beagl.Domain.Models;
using Beagl.Domain.Models.DTOs;
using Beagl.Domain.Services;
using Beagl.Infrastructure.Services.Interfaces;
using Beagl.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beagl.WebApp.Pages.Users;

/// <summary>
/// Page model for creating a new user.
/// </summary>
internal sealed class CreateModel(
    IUserService userService,
    IRoleService roleService) : PageModel
{
    /// <summary>
    /// Gets or sets the new user to be created.
    /// </summary>
    [BindProperty]
    public CreateUserViewModel? NewUser { get; set; }

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
        //TODO: ugly, needs refactor
        if (!ModelState.IsValid)
        {
            AvailableRoles = GetAvailableRoles();
            return Page();
        }

        UserDto userDto = new()
        {
            UserName = NewUser!.UserName,
            Email = NewUser.Email,
            PhoneNumber = NewUser.PhoneNumber,
            Roles = new Collection<string>(NewUser.Roles)
        };

        try
        {
            await userService.CreateAsync(userDto, NewUser.Password);
        }
        catch (ArgumentException aEx)
        {
            ModelState.AddModelError(string.Empty, aEx.Message);
            AvailableRoles = GetAvailableRoles();
            return Page();
        }
        catch (IdentityUpdateFailedException)
        {
            ModelState.AddModelError(string.Empty, "An error occurred while creating the user.");
            AvailableRoles = GetAvailableRoles();
            return Page();
        }

        return RedirectToPage("/Users/Index");
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
