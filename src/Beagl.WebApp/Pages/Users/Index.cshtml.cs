using Beagl.Domain.Models;
using Beagl.Domain.Services;
using Beagl.WebApp.Pages.Shared.Models;

namespace Beagl.WebApp.Pages.Users;

/// <summary>
/// Page model for the Users index page.
/// </summary>
internal sealed class IndexModel(
    IUserService userService) : PaginatedPageModel
{
    public IList<UserDto> Users { get; private set; } = [];

    /// <summary>
    /// Handles GET requests for the page.
    /// </summary>
    public async Task OnGetAsync(int pageNumber = 1) =>
        await LoadPageAsync(pageNumber);

    protected override async Task LoadPageAsync(int pageNumber = 1)
    {
        (Users, TotalItems) = await userService.GetPagedAsync(pageNumber, PageSize);
        SetPagination(pageNumber);
    }
}
