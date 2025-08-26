using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Beagl.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Beagl.Infrastructure.Tests;

public class DatabaseInitializerTests
{
    [Fact]
    public async Task InitializeAsync_CreatesAllRoles()
    {
        // Arrange
        IRoleStore<IdentityRole> roleStore = Mock.Of<IRoleStore<IdentityRole>>();
        IRoleValidator<IdentityRole>[] roleValidators = Array.Empty<IRoleValidator<IdentityRole>>();
        ILookupNormalizer keyNormalizer = Mock.Of<ILookupNormalizer>();
        IdentityErrorDescriber errors = new();
        ILogger<RoleManager<IdentityRole>> logger = Mock.Of<ILogger<RoleManager<IdentityRole>>>();

        var roleManagerMock = new Mock<RoleManager<IdentityRole>>(
            roleStore,
            roleValidators,
            keyNormalizer,
            errors,
            logger);

        roleManagerMock.Setup(rm => rm.RoleExistsAsync(It.IsAny<string>()))
            .ReturnsAsync(false);
        roleManagerMock.Setup(rm => rm.CreateAsync(It.IsAny<IdentityRole>()))
            .ReturnsAsync(IdentityResult.Success);

        Mock<UserManager<IdentityUser>> userManagerMock = new(
            Mock.Of<IUserStore<IdentityUser>>(),
            Mock.Of<IOptions<IdentityOptions>>(),
            Mock.Of<IPasswordHasher<IdentityUser>>(),
            Array.Empty<IUserValidator<IdentityUser>>(),
            Array.Empty<IPasswordValidator<IdentityUser>>(),
            Mock.Of<ILookupNormalizer>(),
            Mock.Of<IdentityErrorDescriber>(),
            Mock.Of<IServiceProvider>(),
            Mock.Of<ILogger<UserManager<IdentityUser>>>());

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
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<IdentityRole>(r => r.Name == RoleNames.Administrator)), Times.Once);
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<IdentityRole>(r => r.Name == RoleNames.Control)), Times.Once);
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<IdentityRole>(r => r.Name == RoleNames.Employee)), Times.Once);
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<IdentityRole>(r => r.Name == RoleNames.Security)), Times.Once);
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<IdentityRole>(r => r.Name == RoleNames.Development)), Times.Once);
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<IdentityRole>(r => r.Name == RoleNames.Marketing)), Times.Once);
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<IdentityRole>(r => r.Name == RoleNames.Finance)), Times.Once);
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<IdentityRole>(r => r.Name == RoleNames.BoardMember)), Times.Once);
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<IdentityRole>(r => r.Name == RoleNames.Sales)), Times.Once);
        roleManagerMock.Verify(rm => rm.CreateAsync(It.Is<IdentityRole>(r => r.Name == RoleNames.Citizen)), Times.Once);
        await dbContext.DisposeAsync();
        roleManagerMock.Object.Dispose();
    }
}
