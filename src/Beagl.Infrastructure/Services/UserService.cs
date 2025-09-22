// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Exceptions.Entities;
using Beagl.Domain.Exceptions.Users;
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
public class UserService(
    UserManager<ApplicationUser> userManager
) : IUserService //TODO: inherit from a paged service base class
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
    public Task DeactivateAsync(string id) => throw new NotImplementedException(); //TODO: not required should be removed

    /// <summary>
    /// Deletes the user with the specified identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task DeleteAsync(string id)
    {
        ArgumentException.ThrowIfNullOrEmpty(id);

        ApplicationUser? user = await userManager.FindByIdAsync(id)
            ?? throw new EntityNotFoundException("User not found.");
        int userCount = await GetUserCountAsync();
        if (userCount <= 1)
            throw new LastUserDeleteException("Cannot delete the last user.");

        IdentityResult result = await userManager.DeleteAsync(user);
        if (!result.Succeeded)
            throw new EntityDeleteFailedException(
                "Failed to delete user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
    }

    /// <summary>
    /// Retrieves all users in the system.
    /// </summary>
    /// <returns>A task that returns an enumerable collection of user data transfer objects.</returns>
    public Task<IEnumerable<UserDto>> GetAllAsync() => throw new NotImplementedException(); //TODO: not required should be removed

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
        ApplyFiltersToQuery(filter, ref query);
        ApplyOrderingByUsernameToQuery(ref query);
        int totalCount = await GetUserCountAsync(query);
        ApplyPagingToQuery(filter, ref query);
        List<ApplicationUser> users = await query.ToListAsync();

        List<UserDto> userDtos = [];
        foreach (ApplicationUser user in users)
        {
            IList<string> roles = await userManager.GetRolesAsync(user);
            UserDto dto = UserMapper.ToDto(user, roles);
            userDtos.Add(dto);
        }

        return (userDtos, totalCount);
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

    /// <summary>
    /// Gets the total number of users in the system.
    /// </summary>
    /// <returns>A task that returns the total user count.</returns>
    public virtual async Task<int> GetUserCountAsync()
        => await GetUserCountAsync(userManager.Users);

    /// <summary>
    /// Gets the total number of users in the system.
    /// </summary>
    /// <returns>A task that returns the total user count.</returns>
    public virtual async Task<int> GetUserCountAsync(IQueryable<ApplicationUser> query)
        => await query.CountAsync();

    private static void ApplyPagingToQuery(
        PagedRequestDto filter,
        ref IQueryable<ApplicationUser> query)
    {
        int skip = (filter.PageNumber - 1) * filter.PageSize;
        query = query.Skip(skip).Take(filter.PageSize);
    }

    private static void ApplyOrderingByUsernameToQuery(
        ref IQueryable<ApplicationUser> query)
    {
        query = query.OrderBy(u => u.UserName);
    }

    private static void ApplyFiltersToQuery(
        UserPagedFilterDto filter,
        ref IQueryable<ApplicationUser> query)
    {
        if (filter != null) //FIXME: should return an exception instead of a null check
        {
            ApplyUserNameFilterToQuery(filter.Username, ref query);
            ApplyEmailFilterToQuery(filter.Email, ref query);
            ApplyPhoneFilterToQuery(filter.Phone, ref query);
        }
    }

    private static void ApplyPhoneFilterToQuery(
        string? phone,
        ref IQueryable<ApplicationUser> query)
    {
        if (!string.IsNullOrWhiteSpace(phone))
        {
            query = query.Where(u => u.PhoneNumber!.Contains(phone));
        }
    }

    private static void ApplyEmailFilterToQuery(
        string? email,
        ref IQueryable<ApplicationUser> query)
    {
        if (!string.IsNullOrWhiteSpace(email))
        {
            query = query.Where(u => u.Email!.Contains(email));
        }
    }

    private static void ApplyUserNameFilterToQuery(
        string? username,
        ref IQueryable<ApplicationUser> query)
    {
        if (!string.IsNullOrWhiteSpace(username))
        {
            query = query.Where(u => u.UserName!.Contains(username));
        }
    }
}
