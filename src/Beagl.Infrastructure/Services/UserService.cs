using Beagl.Domain.Models;
using Beagl.Domain.Services;
using Beagl.Infrastructure.Entities;
using Beagl.Infrastructure.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Beagl.Infrastructure.Services;

/// <summary>
/// Provides user management operations such as creation, deletion, retrieval, and updates.
/// Implements the <see cref="IUserService"/> interface for accessing and managing user data.
/// </summary>
public class UserService
    (UserManager<ApplicationUser> userManager) : IUserService
{
    /// <summary>
    /// Creates a new user with the specified details, password, and role.
    /// </summary>
    /// <param name="user">The user data transfer object containing user details.</param>
    /// <param name="password">The password for the new user.</param>
    /// <param name="role">The role to assign to the new user.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task CreateAsync(UserDto user, string password, string role) => throw new NotImplementedException();

    /// <summary>
    /// Deactivates the user with the specified identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to deactivate.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task DeactivateAsync(string id) => throw new NotImplementedException();

    /// <summary>
    /// Deletes the user with the specified identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task DeleteAsync(string id) => throw new NotImplementedException();

    /// <summary>
    /// Retrieves all users in the system.
    /// </summary>
    /// <returns>A task that returns an enumerable collection of user data transfer objects.</returns>
    public Task<IEnumerable<UserDto>> GetAllAsync() => throw new NotImplementedException();

    /// <summary>
    /// Retrieves a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <returns>A task that returns the user data transfer object if found; otherwise, null.</returns>
    public Task<UserDto?> GetByIdAsync(string id) => throw new NotImplementedException();

    /// <inheritdoc/>
    public async Task<(IList<UserDto> Items, int TotalCount)> GetPagedAsync(
        UserPagedFilterDto filter)
    {
        ArgumentNullException.ThrowIfNull(filter);

        IQueryable<ApplicationUser> query = userManager.Users;
        int totalCount = await query.CountAsync();
        List<UserDto> items = await query
            .OrderBy(u => u.UserName)
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(u => UserMapper.ToDto(u))
            .ToListAsync();

        return (items, totalCount);
    }

    /// <summary>
    /// Sends an invitation to the user with the specified identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to invite.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task SendInvitationAsync(string id) => throw new NotImplementedException();

    /// <summary>
    /// Updates the details of the specified user.
    /// </summary>
    /// <param name="user">The user data transfer object containing updated user details.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task UpdateAsync(UserDto user) => throw new NotImplementedException();
}
