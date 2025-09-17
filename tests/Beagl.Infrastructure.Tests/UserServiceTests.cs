using Beagl.Domain.Exceptions.Entities;
using Beagl.Domain.Exceptions.Users;
using Beagl.Domain.Models;
using Beagl.Infrastructure.Entities;
using Beagl.Infrastructure.Mappers;
using Beagl.Infrastructure.Services;
using Beagl.Infrastructure.Tests.Fakes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Beagl.Infrastructure.Tests;

public class UserServiceTests
{
    private readonly Mock<FakeUserManager> _userManagerMock;

    public UserServiceTests()
    {
        _userManagerMock = new Mock<FakeUserManager>();
    }

    [Fact]
    public async Task DeleteAsync_ThrowsIfIdIsNullOrEmpty()
    {
        UserService service = new(_userManagerMock.Object);
        await Assert.ThrowsAsync<ArgumentNullException>(() => service.DeleteAsync(null!));
        await Assert.ThrowsAsync<ArgumentException>(() => service.DeleteAsync(""));
    }

    [Fact]
    public async Task DeleteAsync_ThrowsIfUserNotFound()
    {
        _userManagerMock.Setup(m => m.FindByIdAsync("id")).ReturnsAsync((ApplicationUser?)null);
        UserService service = new(_userManagerMock.Object);
        await Assert.ThrowsAsync<EntityNotFoundException>(() => service.DeleteAsync("id"));
    }

    /// <summary>
    /// Ensures that deleting the last user throws a LastUserDeleteException.
    /// </summary>
    [Fact]
    public async Task DeleteAsync_ThrowsIfLastUser()
    {
        // Arrange
        ApplicationUser user = new() { Id = "id" };
        _userManagerMock.Setup(m => m.FindByIdAsync("id")).ReturnsAsync(user);
        List<ApplicationUser> users = [user];
        TestAsyncEnumerable<ApplicationUser> queryableUsers = new(users);
        _userManagerMock.Setup(m => m.Users).Returns(queryableUsers);
        Mock<UserService> service = new(_userManagerMock.Object) { CallBase = true };
        service.Setup(s => s.GetUserCountAsync()).ReturnsAsync(1);

        // Act & Assert
        await Assert.ThrowsAsync<LastUserDeleteException>(()
            => service.Object.DeleteAsync("id"));
    }

    [Fact]
    public async Task DeleteAsync_ThrowsIfDeleteFails()
    {
        ApplicationUser user = new() { Id = "id" };
        _userManagerMock.Setup(m => m.FindByIdAsync("id")).ReturnsAsync(user);
        IQueryable<ApplicationUser> users = new List<ApplicationUser> { user, new() { Id = "id2" } }.AsQueryable();
        _userManagerMock.Setup(m => m.Users).Returns(users);
        _userManagerMock.Setup(m => m.DeleteAsync(user)).ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "fail" }));
        Mock<UserService> service = new(_userManagerMock.Object) { CallBase = true };
        service.Setup(s => s.GetUserCountAsync()).ReturnsAsync(2);
        await Assert.ThrowsAsync<EntityDeleteFailedException>(() => service.Object.DeleteAsync("id"));
    }

    [Fact]
    public async Task DeleteAsync_Succeeds()
    {
        ApplicationUser user = new() { Id = "id" };
        _userManagerMock.Setup(m => m.FindByIdAsync("id")).ReturnsAsync(user);
        IQueryable<ApplicationUser> users = new List<ApplicationUser> { user, new() { Id = "id2" } }.AsQueryable();
        _userManagerMock.Setup(m => m.Users).Returns(users);
        _userManagerMock.Setup(m => m.DeleteAsync(user)).ReturnsAsync(IdentityResult.Success);
        Mock<UserService> service = new(_userManagerMock.Object) { CallBase = true };
        service.Setup(s => s.GetUserCountAsync()).ReturnsAsync(2);
        await service.Object.DeleteAsync("id");
    }

    [Fact]
    public async Task GetPagedAsync_ThrowsIfFilterIsNull()
    {
        UserService service = new(_userManagerMock.Object);
        await Assert.ThrowsAsync<ArgumentNullException>(() => service.GetPagedAsync(null!));
    }
}
