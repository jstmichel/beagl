// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using Beagl.Domain.Core.Exceptions;
using Beagl.Infrastructure.UserManagement.Interfaces;
using Beagl.Application.UserManagement.DTOs;
using Beagl.Application.UserManagement.ViewModels;
using Beagl.WebApp.Constants;
using Microsoft.AspNetCore.Authorization;
using Beagl.WebApp.Mappers;

namespace Beagl.WebApp.Pages.Users;

/// <summary>
/// Page model for editing a user.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="EditModel"/> class.
/// </remarks>
/// <param name="userService">The user service.</param>
/// <param name="userQueryService">The user query service.</param>
/// <param name="roleService">The role service.</param>
[Authorize(Policy = Policies.Users.CanEdit)]
internal sealed class EditModel(
    IUserService userService,
    IUserQueryService userQueryService,
    IRoleService roleService) : PageModel
{

    /// <summary>
    /// Gets or sets the user to edit.
    /// </summary>
    [BindProperty]
    public EditUserViewModel? Input { get; set; } = new EditUserViewModel();

    /// <summary>
    /// List of available roles for dropdown selection.
    /// </summary>
    public List<RoleViewModel> AvailableRoles { get; set; } = [];

    /// <summary>
    /// Handles GET requests to load the user for editing.
    /// </summary>
    /// <param name="id">The user ID.</param>
    /// <returns>The page result.</returns>
    public async Task<IActionResult> OnGetAsync(string id)
    {
        try
        {
            UserDto user = await userQueryService.GetByIdAsync(id);
            AvailableRoles = GetAvailableRoles();
            Input = MapToEditUserViewModel(user); //TODO: To replace with mapper
        }
        catch (InvalidOperationException)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
        catch (ArgumentException)
        {
            return BadRequest();
        }
        // catch (EntityNotFoundException)
        // {
        //     return NotFound();
        // }

        return Page();
    }

    /// <summary>
    /// Handles POST requests to update the user details and roles.
    /// </summary>
    /// <returns>The page result.</returns>
    public async Task<IActionResult> OnPostAsync()
    {
        if (Input == null)
        {
            return BadRequest();
        }

        try
        {
            UserDto dto = Input.ToDto();
            await userService.UpdateAsync(dto);
        }
        catch (ArgumentException)
        {
            return BadRequest();
        }
        // catch (EntityNotFoundException)
        // {
        //     return NotFound();
        // }
        catch (InvalidOperationException)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        return RedirectToPage(Redirection.ToUserList);
    }

    /// <summary>
    /// Checks if the edited user has the specified role.
    /// </summary>
    /// <param name="roleName">The name of the role to check.</param>
    /// <returns>True if the user has the role; otherwise, false.</returns>
    public bool HasRole(string roleName)
    {
        ArgumentException.ThrowIfNullOrEmpty(roleName);

        if (Input == null)
        {
            throw new InvalidOperationException("Input cannot be null.");
        }

        if (Input.Roles == null)
        {
            throw new InvalidOperationException("Roles cannot be null.");
        }

        return Input.Roles.Any(r => r == roleName);
    }

    private static EditUserViewModel MapToEditUserViewModel(UserDto user)
    {
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(user.Id);

        return new EditUserViewModel
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Roles = [.. user.Roles]
        };
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
