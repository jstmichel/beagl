// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Exceptions.Entities;
using Beagl.Domain.Exceptions.Users;
using Beagl.Domain.Models;
using Beagl.Domain.Services;
using Beagl.Infrastructure.Services.Interfaces;
using Beagl.WebApp.Pages.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Beagl.WebApp.Pages.Users;

/// <summary>
/// Page model for the Users index page.
/// </summary>
internal sealed class IndexModel(
    IUserService userService,
    IUserQueryService userQueryService,
    IStringLocalizer<IndexModel> localizer) : PaginatedPageModel<UserDto, IndexModel.UserFilterModel>
{
    /// <summary>
    /// Model for filtering users in the user management view.
    /// </summary>
    internal sealed class UserFilterModel
    {
        /// <summary>
        /// Gets or sets the username filter.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the email filter.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the phone filter.
        /// </summary>
        public string? Phone { get; set; }
    }

    /// <summary>
    /// Handles GET requests for the page and returns the rendered page.
    /// </summary>
    /// <param name="pageNumber">The page number to load.</param>
    /// <returns>A task that renders the page with the requested data.</returns>
    public async Task<IActionResult> OnGetAsync(int pageNumber = 1)
    {
        await LoadPageAsync(pageNumber);
        return Page();
    }

    /// <summary>
    /// Loads paginated user data for the page.
    /// </summary>
    /// <param name="pageNumber">The page number to load.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected override async Task LoadPageAsync(int pageNumber = 1)
    {
        UserPagedFilterDto userPagedFilterDto = CreatePagedFilterDto(pageNumber);
        (DataModel, TotalItems) = await userQueryService.GetPagedAsync(userPagedFilterDto);
        SetPagination(pageNumber);
    }

    /// <summary>
    /// Handles POST requests for deleting a user.
    /// </summary>
    /// <param name="id">The ID of the user to delete.</param>
    /// <param name="pageNumber">The current page number.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task<IActionResult> OnPostDeleteAsync(string id, int pageNumber)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            HandleInvalidUserId();
            await LoadPageAsync(pageNumber);
            return Page();
        }

        try
        {
            await userService.DeleteAsync(id);
        }
        catch (EntityDeleteFailedException ex)
        {
            HandleUserDeleteFailed(ex);
        }
        catch (LastUserDeleteException ex)
        {
            HandleLastUserDelete(ex);
        }
        catch (EntityNotFoundException ex)
        {
            HandleUserNotFound(ex);
        }

        await LoadPageAsync(pageNumber);
        return Page();
    }

    private void HandleInvalidUserId() =>
        AddGlobalError(localizer["User ID cannot be empty"].Value);

    private void HandleUserNotFound(EntityNotFoundException ex) =>
        AddGlobalError(localizer["User was not found", ex.Message].Value);

    private void HandleUserDeleteFailed(EntityDeleteFailedException ex) =>
        AddGlobalError(localizer["User deletion failed", ex.Message].Value);

    private void HandleLastUserDelete(LastUserDeleteException ex) =>
        AddGlobalError(localizer["Last user deletion error", ex.Message].Value);

    private UserPagedFilterDto CreatePagedFilterDto(int pageNumber) =>
        new()
        {
            PageNumber = pageNumber,
            PageSize = PageSize,
            Username = FilterModel.Username,
            Email = FilterModel.Email,
            Phone = FilterModel.Phone
        };
}
