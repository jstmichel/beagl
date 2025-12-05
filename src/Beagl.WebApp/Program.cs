// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.Core.Interfaces;
using Beagl.Infrastructure;
using Beagl.Infrastructure.Core.Extensions;
using Beagl.Infrastructure.UserManagement.Entities;
using Beagl.WebApp.Extensions;
using Beagl.WebApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages()
    .AddDataAnnotationsLocalization()
    .AddViewLocalization();

// Add localization services
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Add EF Core DbContext with PostgreSQL
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "Database connection string 'DefaultConnection' is missing from configuration.");
}
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add ASP.NET Core Identity (without default UI), using EF Core for storage
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorizationBuilder().AddPolicies();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.SlidingExpiration = true;
    options.LoginPath = "/Login";
});

builder.Services.AddInfrastructureServices();
builder.Services.AddHandlerServices();
builder.Services.AddQueryServices();
builder.Services.AddMappers();
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
builder.Services.AddWebAppServices();
builder.Services.AddValidators();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

WebApplication app = builder.Build();

// Ensure database is created and migrations are applied at startup
await app.ExecuteMigrationsAsync(builder.Configuration);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

string[] supportedCultures = ["en", "fr"];
RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.MapRazorPages();

await app.RunAsync().ConfigureAwait(false);
