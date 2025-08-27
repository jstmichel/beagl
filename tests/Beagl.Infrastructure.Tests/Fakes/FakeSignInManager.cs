// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;

namespace Beagl.Infrastructure.Tests.Fakes;

public class FakeSignInManager : SignInManager<IdentityUser>
{
    public FakeSignInManager()
        : base(
            new FakeUserManager(),
            new HttpContextAccessor(),
            new Mock<IUserClaimsPrincipalFactory<IdentityUser>>().Object,
            new Mock<Microsoft.Extensions.Options.IOptions<IdentityOptions>>().Object,
            new Mock<ILogger<SignInManager<IdentityUser>>>().Object,
            new Mock<Microsoft.AspNetCore.Authentication.IAuthenticationSchemeProvider>().Object
            )
    { }
}
