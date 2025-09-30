// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Collections.ObjectModel;
using Beagl.Domain.Models;
using Beagl.Domain.Models.DTOs;
using Beagl.Infrastructure.Entities;

namespace Beagl.Infrastructure.Mappers;

/// <summary>
/// Provides mapping methods between ApplicationUser entities and UserDto data transfer objects.
/// </summary>
public static class UserMapper
{
    /// <summary>
    /// Maps an ApplicationUser entity to a UserDto.
    /// </summary>
    /// <param name="user">The ApplicationUser entity to map.</param>
    /// <param name="roles">The roles assigned to the user.</param>
    /// <returns>A UserDto representing the user.</returns>
    public static UserDto ToDto(ApplicationUser user, IList<RoleDto> roles)
    {
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(roles);

        return new UserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            IsDeleted = user.IsDeleted,
            Roles = new Collection<RoleDto>(roles)
        };
    }

    /// <summary>
    /// Maps a UserDto to an ApplicationUser entity.
    /// </summary>
    /// <param name="dto">The UserDto to map.</param>
    /// <returns>An ApplicationUser entity representing the DTO.</returns>
    public static ApplicationUser ToEntity(UserDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        return new ApplicationUser
        {
            Id = dto.Id,
            UserName = dto.UserName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            IsDeleted = dto.IsDeleted
        };
    }
}
