// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Models.Results;
using Beagl.Infrastructure.Entities;
using Beagl.Infrastructure.Services;
using Beagl.Infrastructure.Tests.Fakes;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace Beagl.Infrastructure.Tests;

/// <summary>
/// Unit tests for <see cref="AuthenticationService"/>.
/// </summary>
public sealed class AuthenticationServiceTests
{
    private readonly Mock<FakeSignInManager> _signInManagerMock;
    private readonly Mock<FakeUserManager> _userManagerMock;

    public AuthenticationServiceTests()
    {
        _signInManagerMock = new Mock<FakeSignInManager>();
        _userManagerMock = new Mock<FakeUserManager>();
    }

    [Fact]
    public async Task SignInAsync_ReturnsTrue_WhenSignInSucceeds()
    {
        // Arrange
        ApplicationUser user = new() { Email = "user@example.com", IsDeleted = false };
        _userManagerMock
            .Setup(m => m.FindByEmailAsync("user@example.com"))
            .ReturnsAsync(user);
        _signInManagerMock
            .Setup(m => m.PasswordSignInAsync("user@example.com", "password", false, true))
            .ReturnsAsync(SignInResult.Success);

        AuthenticationService service = new(
            _signInManagerMock.Object,
            _userManagerMock.Object);

        // Act
        AuthenticationResult result = await service.SignInAsync(
            "user@example.com", "password", isPersistent: false);

        // Assert
        Assert.True(result.Succeeded);
    }

    [Fact]
    public async Task SignInAsync_ReturnsFalse_WhenSignInFails()
    {
        // Arrange
        ApplicationUser user = new() { Email = "user@example.com", IsDeleted = false };
        _userManagerMock
            .Setup(m => m.FindByEmailAsync("user@example.com"))
            .ReturnsAsync(user);
        _signInManagerMock
            .Setup(m => m.PasswordSignInAsync("user@example.com", "wrongpassword", false, true))
            .ReturnsAsync(SignInResult.Failed);

        AuthenticationService service = new(
            _signInManagerMock.Object,
            _userManagerMock.Object);

        // Act
        AuthenticationResult result = await service.SignInAsync(
            "user@example.com", "wrongpassword", isPersistent: false);

        // Assert
        Assert.False(result.Succeeded);
    }

    [Fact]
    public async Task SignInAsync_ReturnsFalse_WhenUserIsDeleted()
    {
        // Arrange
        ApplicationUser user = new() { Email = "user@example.com", IsDeleted = true };
        _userManagerMock
            .Setup(m => m.FindByEmailAsync("user@example.com"))
            .ReturnsAsync(user);

        AuthenticationService service = new(
            _signInManagerMock.Object,
            _userManagerMock.Object);

        // Act
        AuthenticationResult result = await service.SignInAsync(
            "user@example.com", "password", isPersistent: false);

        // Assert
        Assert.False(result.Succeeded);
    }

    [Fact]
    public async Task SignInAsync_ReturnsFalse_WhenUserDoesNotExist()
    {
        // Arrange
        _userManagerMock
            .Setup(m => m.FindByEmailAsync("user@example.com"))
            .ReturnsAsync((ApplicationUser?)null);

        AuthenticationService service = new(
            _signInManagerMock.Object,
            _userManagerMock.Object);

        // Act
        AuthenticationResult result = await service.SignInAsync(
            "user@example.com", "password", isPersistent: false);

        // Assert
        Assert.False(result.Succeeded);
    }

    [Fact]
    public async Task SignOutAsync_CallsSignInManagerSignOutAsync()
    {
        // Arrange
        _signInManagerMock
            .Setup(m => m.SignOutAsync())
            .Returns(Task.CompletedTask)
            .Verifiable();

        AuthenticationService service = new(
            _signInManagerMock.Object,
            _userManagerMock.Object);

        // Act
        await service.SignOutAsync();

        // Assert
        _signInManagerMock.Verify(m => m.SignOutAsync(), Times.Once);
    }
}
