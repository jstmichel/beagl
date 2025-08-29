// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Models.Results;
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
    [Fact]
    public async Task SignInAsync_ReturnsTrue_WhenSignInSucceeds()
    {
        // Arrange
        Mock<FakeSignInManager> signInManagerMock = new();

        signInManagerMock
            .Setup(m => m.PasswordSignInAsync("user@example.com", "password", false, true))
            .ReturnsAsync(SignInResult.Success);

        AuthenticationService service = new(signInManagerMock.Object);

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
        Mock<FakeSignInManager> signInManagerMock = new();

        signInManagerMock
            .Setup(m => m.PasswordSignInAsync("user@example.com", "wrongpassword", false, true))
            .ReturnsAsync(SignInResult.Failed);

        AuthenticationService service = new(signInManagerMock.Object);

        // Act
        AuthenticationResult result = await service.SignInAsync(
            "user@example.com", "wrongpassword", isPersistent: false);

        // Assert
        Assert.False(result.Succeeded);
    }

    [Fact]
    public async Task SignOutAsync_CallsSignInManagerSignOutAsync()
    {
        // Arrange
        Mock<FakeSignInManager> signInManagerMock = new();
        signInManagerMock
            .Setup(m => m.SignOutAsync())
            .Returns(Task.CompletedTask)
            .Verifiable();

        AuthenticationService service = new(signInManagerMock.Object);

        // Act
        await service.SignOutAsync();

        // Assert
        signInManagerMock.Verify(m => m.SignOutAsync(), Times.Once);
    }
}
