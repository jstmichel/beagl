// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.Extensions.Configuration;
using Moq;
using Beagl.WebApp.Extensions;
using Microsoft.AspNetCore.Builder;

namespace Beagl.WebApp.Tests;

public class WebApplicationExtensionsTests
{
    [Fact]
    public async Task ExecuteMigrationsAsync_ThrowsArgumentNullException_WhenAppIsNull()
    {
        // Arrange
        IConfiguration config = new ConfigurationBuilder().Build();

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() =>
            WebApplicationExtensions.ExecuteMigrationsAsync(null!, config));
    }

    [Fact]
    public async Task ExecuteMigrationsAsync_ThrowsArgumentNullException_WhenConfigIsNull()
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() =>
            WebApplicationExtensions.ExecuteMigrationsAsync(WebApplication.Create(), null!));
    }

    // Note: To test the call to DatabaseInitializer.InitializeAsync, you would need to refactor the extension method to allow injection/mocking.
}
