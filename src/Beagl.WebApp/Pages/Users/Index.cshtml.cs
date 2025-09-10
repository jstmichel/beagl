using System.ComponentModel.DataAnnotations;
using Beagl.Domain.Models;
using Beagl.Domain.Services;
using Beagl.WebApp.Pages.Shared.Models;

namespace Beagl.WebApp.Pages.Users;

/// <summary>
/// Page model for the Users index page.
/// </summary>
internal sealed class IndexModel(
    IUserService userService) :
    PaginatedPageModel<UserDto, IndexModel.UserFilterModel>
{
    /// <summary>
    /// Model for filtering users in the user management view.
    /// </summary>
    internal sealed class UserFilterModel
    {
        /// <summary>
        /// Gets or sets the username filter.
        /// </summary>
    [Display(Name = nameof(Beagl.WebApp.Resources.IndexModel.Username), ResourceType = typeof(Beagl.WebApp.Resources.IndexModel))]
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the email filter.
        /// </summary>
    [Display(Name = nameof(Beagl.WebApp.Resources.IndexModel.Email), ResourceType = typeof(Beagl.WebApp.Resources.IndexModel))]
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the phone filter.
        /// </summary>
    [Display(Name = nameof(Beagl.WebApp.Resources.IndexModel.Phone), ResourceType = typeof(Beagl.WebApp.Resources.IndexModel))]
        public string? Phone { get; set; }
    }

    /// <summary>
    /// Handles GET requests for the page.
    /// </summary>
    public async Task OnGetAsync(int pageNumber = 1) =>
        await LoadPageAsync(pageNumber);

    protected override async Task LoadPageAsync(int pageNumber = 1)
    {
        (DataModel, TotalItems) = await userService.GetPagedAsync(
            new UserPagedFilterDto
            {
                PageNumber = pageNumber,
                PageSize = PageSize,
                Username = FilterModel.Username,
                Email = FilterModel.Email,
                Phone = FilterModel.Phone
            }
        );
        SetPagination(pageNumber);
    }
}
