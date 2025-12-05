// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.UserManagement.DTOs;
using Beagl.Infrastructure.UserManagement.Entities;

namespace Beagl.Infrastructure.UserManagement.Services;

/// <summary>
/// Provides methods to retrieve application roles.
/// </summary>
public interface IRoleService
{
    /// <summary>
    /// Retrieves all available application roles.
    /// </summary>
    /// <returns>A list of <see cref="ApplicationRole"/> objects.</returns>
    public IList<RoleDto> GetAllRoles();
}
