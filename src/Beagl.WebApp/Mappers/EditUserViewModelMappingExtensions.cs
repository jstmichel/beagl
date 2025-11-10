// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Collections.ObjectModel;
using Beagl.Application.UserManagement.DTOs;
using Beagl.Application.UserManagement.ViewModels;

namespace Beagl.WebApp.Mappers;

internal static class EditUserViewModelMappingExtensions
{
    /// <summary>
    /// Maps an EditUserViewModel to a UserDto.
    /// </summary>
    /// <param name="editedUser">The EditUserViewModel to map.</param>
    /// <returns>The mapped UserDto.</returns>
    public static UserDto ToDto(this EditUserViewModel editedUser)
    {
        ArgumentNullException.ThrowIfNull(editedUser);

        return new UserDto
        {
            Id = editedUser.Id!,
            UserName = editedUser.UserName!,
            Email = editedUser.Email!,
            PhoneNumber = editedUser.PhoneNumber,
            Roles = new Collection<string>(editedUser.Roles)
        };
    }
}
