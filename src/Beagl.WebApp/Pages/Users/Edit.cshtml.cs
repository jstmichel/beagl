// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Beagl.Domain.Models;
using Beagl.Domain.Services;
using Beagl.Infrastructure.Services.Interfaces;
using Beagl.Domain.Exceptions.Entities;
using Beagl.Domain.Models.DTOs;
using System.Net;
using Beagl.WebApp.ViewModels;
using System.Collections.ObjectModel;

namespace Beagl.WebApp.Pages.Users;

/// <summary>
/// Page model for editing a user.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="EditModel"/> class.
/// </remarks>
/// <param name="userService">The user service.</param>
/// <param name="roleService">The role service.</param>
internal sealed class EditModel(
    IUserService userService,
    IRoleService roleService) : PageModel
{

    /// <summary>
    /// Gets or sets the user to edit.
    /// </summary>
    [BindProperty]
    public EditUserViewModel? EditedUser { get; set; }

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
            UserDto user = await userService.GetByIdAsync(id);
            AvailableRoles = GetAvailableRoles();
            EditedUser = MapToEditUserViewModel(user);
        }
        catch (InvalidOperationException)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
        catch (ArgumentException)
        {
            return BadRequest();
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }

        return Page();
    }

    /// <summary>
    /// Handles POST requests to update the user details and roles.
    /// </summary>
    /// <returns>The page result.</returns>
    public async Task<IActionResult> OnPostAsync()
    {
        if (EditedUser == null)
        {
            return BadRequest();
        }

        try
        {
            UserDto user = MapToUserDto(EditedUser);
            await userService.UpdateAsync(user);
        }
        catch (ArgumentException)
        {
            return BadRequest();
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }
        catch (InvalidOperationException)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        return RedirectToPage("Index");
    }

    /// <summary>
    /// Checks if the edited user has the specified role.
    /// </summary>
    /// <param name="roleName">The name of the role to check.</param>
    /// <returns>True if the user has the role; otherwise, false.</returns>
    public bool HasRole(string roleName)
    {
        ArgumentException.ThrowIfNullOrEmpty(roleName);

        if (EditedUser == null)
        {
            throw new InvalidOperationException("EditedUser cannot be null.");
        }

        if (EditedUser.Roles == null)
        {
            throw new InvalidOperationException("Roles cannot be null.");
        }

        return EditedUser.Roles.Any(r => r == roleName);
    }

    private static UserDto MapToUserDto(EditUserViewModel editedUser)
    {
        ArgumentNullException.ThrowIfNull(editedUser);

        return new UserDto
        {
            Id = editedUser.Id,
            UserName = editedUser.UserName,
            Email = editedUser.Email,
            PhoneNumber = editedUser.PhoneNumber,
            Roles = new Collection<string>(editedUser.Roles)
        };
    }

    private static EditUserViewModel MapToEditUserViewModel(UserDto user)
    {
        ArgumentNullException.ThrowIfNull(user);

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

    /// <summary>
    /// Helper class for role dropdown items.
    /// </summary>
    internal sealed class RoleViewModel
    {
        public string Name { get; set; } = string.Empty;
    }
}
