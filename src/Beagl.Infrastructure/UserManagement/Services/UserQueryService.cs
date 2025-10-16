// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Core.Exceptions;
using Beagl.Domain.Extensions;
using Beagl.Infrastructure.UserManagement.DTOs;
using Beagl.Infrastructure.UserManagement.Entities;
using Beagl.Infrastructure.UserManagement.Interfaces;
using Beagl.Infrastructure.UserManagement.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Beagl.Infrastructure.UserManagement.Services;

/// <summary>
/// Service for querying user information.
/// </summary>
public class UserQueryService(
    UserManager<ApplicationUser> userManager) : IUserQueryService
{
    /// <inheritdoc/>
    public virtual async Task<int> GetUserCountAsync()
        => await GetUserCountAsync(userManager.Users);

    /// <inheritdoc/>
    public virtual async Task<int> GetUserCountAsync(IQueryable<ApplicationUser> query)
        => await query.CountAsync();

    /// <inheritdoc/>
    public async Task<ApplicationUser> FindUserByIdAsync(string id)
    {
        ApplicationUser? user = await userManager.FindByIdAsync(id)
            ?? throw new EntityNotFoundException("User not found.");

        return user;
    }

    /// <inheritdoc/>
    public async Task<UserDto> GetByIdAsync(string id)
    {
        ArgumentException.ThrowIfNullOrEmpty(id);
        ApplicationUser user = await FindUserByIdAsync(id);
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
        IList<string> roles = await userManager.GetRolesAsync(user);
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
