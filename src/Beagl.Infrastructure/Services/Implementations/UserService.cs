// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Exceptions.Entities;
using Beagl.Domain.Exceptions.Users;
using Beagl.Domain.Extensions;
using Beagl.Domain.Models;
using Beagl.Domain.Models.DTOs;
using Beagl.Domain.Services;
using Beagl.Infrastructure.Entities;
using Beagl.Infrastructure.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Beagl.Infrastructure.Services.Implementations;

/// <summary>
/// Provides user management operations such as creation, deletion, retrieval, and updates.
/// Implements the <see cref="IUserService"/> interface for accessing and managing user data.
/// </summary>
public class UserService(
    UserManager<ApplicationUser> userManager
) : IUserService, IPagedService<UserDto, UserPagedFilterDto>
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
    /// Retrieves a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <returns>A task that returns the user data transfer object if found; otherwise, null.</returns>
    public async Task<UserDto?> GetByIdAsync(string id)
    {
        ArgumentException.ThrowIfNullOrEmpty(id);
        ApplicationUser? user = await userManager.FindByIdAsync(id)
            ?? throw new EntityNotFoundException("User not found.");
        return await GetAndMapRolesToUser(user);
    }

    /// <inheritdoc/>
    public async Task<(IList<UserDto> Items, int TotalCount)> GetPagedAsync(
        UserPagedFilterDto filter)
    {
        ArgumentNullException.ThrowIfNull(filter);

        IQueryable<ApplicationUser> query = userManager.Users;
        query = ApplyFiltersToQuery(query, filter);
        query = ApplyOrderingByUsernameToQuery(query);
        int totalCount = await GetUserCountAsync(query);

        List<ApplicationUser> users = await query
            .Paginate(filter.PageNumber, filter.PageSize)
            .ToListAsync();

        List<UserDto> userWithRolesDtos = await GetAndMapRolesToUsers(users);

        return (userWithRolesDtos, totalCount);
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

    private async Task<List<UserDto>> GetAndMapRolesToUsers(
        IList<ApplicationUser> users)
    {
        List<UserDto> userDtos = [];

        foreach (ApplicationUser user in users)
        {
            UserDto dto = await GetAndMapRolesToUser(user);
            userDtos.Add(dto);
        }

        return userDtos;
    }

    private async Task<UserDto> GetAndMapRolesToUser(
        ApplicationUser user)
    {
        //TODO: Extract the two below lines to RoleService or
        // new method in UserService
        IList<string> roleStrings = await userManager.GetRolesAsync(user);
        IList<RoleDto> roles = [.. roleStrings.Select(r => new RoleDto { Name = r })];

        UserDto dto = UserMapper.ToDto(user, roles);
        return dto;
    }

    private static IQueryable<ApplicationUser> ApplyOrderingByUsernameToQuery(
        IQueryable<ApplicationUser> query)
    {
        return query.OrderBy(u => u.UserName);
    }

    private static IQueryable<ApplicationUser> ApplyFiltersToQuery(
        IQueryable<ApplicationUser> query,
        UserPagedFilterDto filter)
    {
        ArgumentNullException.ThrowIfNull(query);
        ArgumentNullException.ThrowIfNull(filter);

        query = ApplyUserNameFilterToQuery(query, filter.Username);
        query = ApplyEmailFilterToQuery(query, filter.Email);
        query = ApplyPhoneFilterToQuery(query, filter.Phone);

        return query;
    }

    private static IQueryable<ApplicationUser> ApplyPhoneFilterToQuery(
        IQueryable<ApplicationUser> query,
        string? phone)
    {
        if (!string.IsNullOrWhiteSpace(phone))
        {
            query = query.Where(u => u.PhoneNumber!.Contains(phone));
        }

        return query;
    }

    private static IQueryable<ApplicationUser> ApplyEmailFilterToQuery(
        IQueryable<ApplicationUser> query,
        string? email)
    {
        if (!string.IsNullOrWhiteSpace(email))
        {
            query = query.Where(u => u.Email!.Contains(email));
        }

        return query;
    }

    private static IQueryable<ApplicationUser> ApplyUserNameFilterToQuery(
        IQueryable<ApplicationUser> query,
        string? username)
    {
        if (!string.IsNullOrWhiteSpace(username))
        {
            query = query.Where(u => u.UserName!.Contains(username));
        }

        return query;
    }
}
