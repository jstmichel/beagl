// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Beagl.Domain.AnimalManagement;
using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Infrastructure.UserManagement.Entities;

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
    public DbSet<Animal> Animals { get; set; } = null!;

    /// <summary>
    /// Gets or sets the HealthRecords table.
    /// </summary>
    public DbSet<HealthRecord> HealthRecords { get; set; } = null!;

    /// <summary>
    /// Gets or sets the MedalRecords table.
    /// </summary>
    public DbSet<MedalRecord> MedalRecords { get; set; } = null!;

    /// <summary>
    /// Configures the model for Animal, HealthRecord, and complex types.
    /// </summary>
    /// <param name="builder">The model builder.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        base.OnModelCreating(builder);

        builder.Entity<MedalRecord>(entity =>
        {
            entity.Property(m => m.MedalNumber).IsRequired();
            entity.Property(m => m.AssignedDate).IsRequired();
            entity.Property(m => m.Reason);
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

        // Configure all value objects as owned types for Animal
        builder.Entity<Animal>(entity =>
        {
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
            entity.OwnsOne(a => a.Breed, b =>
            {
                b.Property(p => p.Primary).HasColumnName("PrimaryBreed");
                b.Property(p => p.Secondary).HasColumnName("SecondaryBreed");
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

        builder.Entity<HealthRecord>(entity =>
        {
            entity.OwnsOne(hr => hr.Weight, w =>
            {
                w.Property(p => p.Value).HasColumnName("WeightValue");
                w.Property(p => p.Unit).HasColumnName("WeightUnit");
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
