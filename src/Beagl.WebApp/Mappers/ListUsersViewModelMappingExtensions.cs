// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.UserManagement.DTOs;
using Beagl.WebApp.Pages.Users.ViewModels;

namespace Beagl.WebApp.Mappers;

internal static class ListUsersViewModelMappingExtensions
{
    /// <summary>
    /// Maps a <see cref="UserDto"/> to a <see cref="ListUsersViewModel"/>.
    /// </summary>
    /// <param name="dto">The DTO to map.</param>
    /// <returns>The mapped ViewModel.</returns>
    public static ListUsersViewModel ToViewModel(this UserDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        return new ListUsersViewModel
        {
            Id = dto.Id,
            UserName = dto.UserName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber ?? string.Empty,
            LockoutEnd = dto.LockoutEnd,
            EmailConfirmed = dto.EmailConfirmed,
            Roles = [.. dto.Roles]
        };
    }
}
