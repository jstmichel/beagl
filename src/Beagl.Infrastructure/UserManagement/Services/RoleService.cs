// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Identity;
using Beagl.Infrastructure.UserManagement.Entities;
using Beagl.Infrastructure.UserManagement.Interfaces;
using Beagl.Application.UserManagement.DTOs;

namespace Beagl.Infrastructure.UserManagement.Services;

/// <summary>
/// Implementation of <see cref="IRoleService"/> using ASP.NET Core Identity RoleManager.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="RoleService"/> class.
/// </remarks>
/// <param name="roleManager">The ASP.NET Core Identity role manager.</param>
public sealed class RoleService(RoleManager<ApplicationRole> roleManager) : IRoleService
{
    /// <inheritdoc />
    public IList<RoleDto> GetAllRoles()
    {
        return [.. roleManager.Roles.Select(r => new RoleDto
        {
            Name = r.Name!,
        })];
    }
}
