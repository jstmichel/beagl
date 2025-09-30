// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Beagl.Domain.Models;
using Beagl.Domain.Services;
using Beagl.Infrastructure.Services.Interfaces;
using Beagl.Infrastructure.Entities;
using Beagl.Domain.Exceptions.Entities;
using Beagl.Domain.Models.DTOs;
using System.Net;

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
    public UserDto? EditedUser { get; set; }

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
            AvailableRoles = GetAvailableRoles();
            EditedUser = await userService.GetByIdAsync(id);
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

        return EditedUser.Roles.Any(r => r.Name == roleName);
    }

    /// <summary>
    /// Helper class for role dropdown items.
    /// </summary>
    internal sealed class RoleViewModel
    {
        public string Name { get; set; } = string.Empty;
    }
}
