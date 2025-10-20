// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Beagl.Infrastructure.UserManagement.Entities;
using Beagl.Infrastructure.AnimalManagement.Models;

namespace Beagl.Infrastructure;

/// <summary>
/// Represents the Entity Framework database context for the application.
/// </summary>
/// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
{
    /// <summary>
    /// Gets or sets the Animals table.
    /// </summary>
    public DbSet<AnimalModel> Animals { get; set; } = null!;

    /// <summary>
    /// Gets or sets the Species table.
    /// </summary>
    public DbSet<SpeciesModel> Species { get; set; } = null!;

    /// <summary>
    /// Gets or sets the Colors table.
    /// </summary>
    public DbSet<ColorModel> Colors { get; set; } = null!;

    /// <summary>
    /// Gets or sets the Breeds table.
    /// </summary>
    public DbSet<BreedModel> Breeds { get; set; } = null!;

    /// <summary>
    /// Configures the model for Animal, HealthRecord, and complex types.
    /// </summary>
    /// <param name="builder">The model builder.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        base.OnModelCreating(builder);

        // Configure AnimalModel relationships and owned types
        builder.Entity<AnimalModel>(entity =>
        {
            // Relationships
            entity.HasOne(a => a.Species)
                .WithMany()
                .HasForeignKey(a => a.SpeciesId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.PrimaryBreed)
                .WithMany()
                .HasForeignKey(a => a.PrimaryBreedId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.SecondaryBreed)
                .WithMany()
                .HasForeignKey(a => a.SecondaryBreedId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.Color)
                .WithMany()
                .HasForeignKey(a => a.ColorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Owned value objects
            entity.OwnsOne(a => a.OriginCityInfo, oci =>
            {
                oci.Property(x => x.ComesFromAnotherCity).HasColumnName("ComesFromAnotherCity");
                oci.Property(x => x.HadJudgmentInThatCity).HasColumnName("HadJudgmentInThatCity");
            });
            entity.OwnsOne(a => a.Gender, g =>
            {
                g.Property(x => x.Value).HasColumnName("Gender");
            });
            entity.OwnsOne(a => a.Photo, p =>
            {
                p.Property(x => x.Base64Png).HasColumnName("PhotoBase64Png");
            });
            entity.OwnsOne(a => a.Microchip, m =>
            {
                m.Property(x => x.Value).HasColumnName("Microchip");
            });
            entity.OwnsOne(a => a.DangerousDog, dd =>
            {
                dd.Property(p => p.IsDangerous).HasColumnName("IsDangerousDog");
                dd.Property(p => p.HasResponsibilityInsurance).HasColumnName("HasDangerousDogInsurance");
                dd.Property(p => p.Comment).HasColumnName("DangerousDogComment");
            });
            entity.OwnsOne(hr => hr.Created, a =>
            {
                a.Property(p => p.UserId).HasColumnName("CreatedByUserId");
                a.Property(p => p.At).HasColumnName("CreatedAt");
            });
            entity.OwnsOne(hr => hr.Modified, a =>
            {
                a.Property(p => p.UserId).HasColumnName("ModifiedByUserId");
                a.Property(p => p.At).HasColumnName("ModifiedAt");
            });
        });
    }
}
