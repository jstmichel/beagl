using Beagl.Domain.Models;
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
    /// <returns>A UserDto representing the user.</returns>
    public static UserDto ToDto(ApplicationUser user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(
                nameof(user),
                "user cannot be null");
        }

        return new UserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            IsDeleted = user.IsDeleted,
        };
    }

    /// <summary>
    /// Maps a UserDto to an ApplicationUser entity.
    /// </summary>
    /// <param name="dto">The UserDto to map.</param>
    /// <returns>An ApplicationUser entity representing the DTO.</returns>
    public static ApplicationUser ToEntity(UserDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(
                nameof(dto),
                "dto cannot be null");
        }

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
