// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Beagl.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Beagl.Infrastructure.Entities;

namespace Beagl.Infrastructure.Tests;

public class DatabaseInitializerTests
{
    [Fact]
    public async Task InitializeAsync_CreatesAllRoles()
    {
        // Arrange
        IRoleStore<ApplicationRole> roleStore = Mock.Of<IRoleStore<ApplicationRole>>();
        IRoleValidator<ApplicationRole>[] roleValidators = Array.Empty<IRoleValidator<ApplicationRole>>();
        ILookupNormalizer keyNormalizer = Mock.Of<ILookupNormalizer>();
        IdentityErrorDescriber errors = new();
        ILogger<RoleManager<ApplicationRole>> logger = Mock.Of<ILogger<RoleManager<ApplicationRole>>>();

        var roleManagerMock = new Mock<RoleManager<ApplicationRole>>(
            roleStore,
            roleValidators,
            keyNormalizer,
            errors,
            logger);

        roleManagerMock.Setup(rm => rm.RoleExistsAsync(It.IsAny<string>()))
            .ReturnsAsync(false);
        roleManagerMock.Setup(rm => rm.CreateAsync(It.IsAny<ApplicationRole>()))
            .ReturnsAsync(IdentityResult.Success);

        Mock<UserManager<ApplicationUser>> userManagerMock = new(
            Mock.Of<IUserStore<ApplicationUser>>(),
            Mock.Of<IOptions<IdentityOptions>>(),
            Mock.Of<IPasswordHasher<ApplicationUser>>(),
            Array.Empty<IUserValidator<ApplicationUser>>(),
            Array.Empty<IPasswordValidator<ApplicationUser>>(),
            Mock.Of<ILookupNormalizer>(),
            Mock.Of<IdentityErrorDescriber>(),
            Mock.Of<IServiceProvider>(),
            Mock.Of<ILogger<UserManager<ApplicationUser>>>());

        DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        ApplicationDbContext dbContext = new(dbContextOptions);

        ServiceCollection serviceCollection = new();
        serviceCollection.AddSingleton(roleManagerMock.Object);
        serviceCollection.AddSingleton(userManagerMock.Object);
        serviceCollection.AddSingleton(dbContext);
        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

        IConfigurationRoot configuration = new ConfigurationBuilder().Build();

        // Act
        await DatabaseInitializer.InitializeAsync(serviceProvider, configuration, migrate: false);

        // Assert
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<ApplicationRole>(r => r.Name == RoleNames.Administrator)), Times.Once);
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<ApplicationRole>(r => r.Name == RoleNames.Control)), Times.Once);
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<ApplicationRole>(r => r.Name == RoleNames.Employee)), Times.Once);
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<ApplicationRole>(r => r.Name == RoleNames.Security)), Times.Once);
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<ApplicationRole>(r => r.Name == RoleNames.Development)), Times.Once);
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<ApplicationRole>(r => r.Name == RoleNames.Marketing)), Times.Once);
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<ApplicationRole>(r => r.Name == RoleNames.Finance)), Times.Once);
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<ApplicationRole>(r => r.Name == RoleNames.BoardMember)), Times.Once);
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<ApplicationRole>(r => r.Name == RoleNames.Sales)), Times.Once);
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<ApplicationRole>(r => r.Name == RoleNames.Citizen)), Times.Once);
        await dbContext.DisposeAsync();
        roleManagerMock.Object.Dispose();
    }
}
