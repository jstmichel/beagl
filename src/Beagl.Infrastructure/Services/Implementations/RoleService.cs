// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Identity;
using Beagl.Infrastructure.Entities;
using Beagl.Infrastructure.Services.Interfaces;
using Beagl.Domain.Models.DTOs;

namespace Beagl.Infrastructure.Services.Implementations;

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
