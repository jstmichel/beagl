// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Collections.ObjectModel;
using Beagl.Application.UserManagement.DTOs;
using Beagl.Application.UserManagement.ViewModels;

namespace Beagl.WebApp.Mappers;

internal static class CreateUserViewModelMappingExtensions
{
    /// <summary>
    /// Maps a CreateUserViewModel to a UserDto.
    /// </summary>
    /// <param name="createdUser">The CreateUserViewModel to map.</param>
    /// <returns>The mapped UserDto.</returns>
    public static UserDto ToDto(this CreateUserViewModel createdUser)
    {
        return new UserDto
        {
            UserName = createdUser.UserName,
            Email = createdUser.Email,
            PhoneNumber = createdUser.PhoneNumber,
            Roles = new Collection<string>(createdUser.Roles)
        };
    }
}
