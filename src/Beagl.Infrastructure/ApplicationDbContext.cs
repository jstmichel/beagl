// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Beagl.Infrastructure.UserManagement.Entities;
using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.CitizenManagement.Entities;

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
    /// Gets or sets the Dogs table.
    /// </summary>
    public DbSet<Dog> Dogs { get; set; } = null!;

    /// <summary>
    /// Gets or sets the Cats table.
    /// </summary>
    public DbSet<Cat> Cats { get; set; } = null!;

    /// <summary>
    /// Gets or sets the Colors table.
    /// </summary>
    public DbSet<Color> Colors { get; set; } = null!;

    /// <summary>
    /// Gets or sets the Breeds table.
    /// </summary>
    public DbSet<Breed> Breeds { get; set; } = null!;

    /// <summary>
    /// Gets or sets the Citizens table.
    /// </summary>
    public DbSet<Citizen> Citizens { get; set; } = null!;



    /// <summary>
    /// Configures the model for Animal, HealthRecord, and complex types.
    /// </summary>
    /// <param name="builder">The model builder.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.OnModelCreating(builder);

        ConfigureBreedEntity(builder);
        ConfigureColorEntity(builder);
        ConfigureAnimalEntity(builder);
        ConfigureCitizenEntity(builder);
        ConfigureDogEntity(builder);
        ConfigureCatEntity(builder);
    }

    private static void ConfigureBreedEntity(ModelBuilder builder)
    {
        builder.Entity<Breed>(entity =>
        {
            entity.ToTable("Breeds");
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(64);
            entity.Property(b => b.SpeciesType)
                .IsRequired();
        });
    }

    private static void ConfigureColorEntity(ModelBuilder builder)
    {
        builder.Entity<Color>(entity =>
        {
            entity.ToTable("Colors");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(64);
            entity.Property(c => c.SpeciesType)
                .IsRequired();
        });
    }

    private static void ConfigureAnimalEntity(ModelBuilder builder)
    {
        builder.Entity<Animal>(entity =>
        {
            entity.ToTable("Animals");
            entity.HasOne(a => a.PrimaryBreed)
                .WithMany()
                .HasForeignKey(a => a.PrimaryBreedId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.Color)
                .WithMany()
                .HasForeignKey(a => a.ColorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.Citizen)
                .WithMany(c => c.Animals)
                .HasForeignKey(a => a.CitizenId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasIndex(a => a.CitizenId);

            entity.OwnsOne(a => a.Photo, p =>
            {
                p.Property(x => x.Base64Png).HasColumnName("PhotoBase64Png");
            });
            entity.OwnsOne(a => a.Microchip, m =>
            {
                m.Property(x => x.Value).HasColumnName("Microchip");
            });
            entity.OwnsOne(hr => hr.Weight, a =>
            {
                a.Property(p => p.Value).HasColumnName("Weight");
                a.Property(p => p.Unit).HasColumnName("WeightUnit");
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
            entity.OwnsOne(a => a.Medal, m =>
            {
                m.Property(x => x.Value).HasColumnName("Medal");
            });
            entity.OwnsOne(a => a.RabiesVaccination, m =>
            {
                m.Property(x => x.IsVaccinated).HasColumnName("IsRabiesVaccinated");
                m.Property(x => x.VaccinationDate).HasColumnName("RabiesVaccinationDate");
            });
        });
    }

    private static void ConfigureCitizenEntity(ModelBuilder builder)
    {
        builder.Entity<Citizen>(entity =>
        {
            entity.ToTable("Citizens");
            entity.HasKey(c => c.Id);

            entity.OwnsOne(c => c.Person, pn =>
            {
                pn.Property(p => p.Civility).HasColumnName("Civility");
                pn.Property(p => p.FirstName).HasColumnName("FirstName");
                pn.Property(p => p.LastName).HasColumnName("LastName");
            });

            entity.OwnsOne(c => c.Phone, p =>
            {
                p.Property(x => x.Value).HasColumnName("Phone");
            });
            entity.OwnsOne(c => c.CellPhone, p =>
            {
                p.Property(x => x.Value).HasColumnName("CellPhone");
            });

            entity.OwnsOne(c => c.Created, a =>
            {
                a.Property(p => p.UserId).HasColumnName("CreatedByUserId");
                a.Property(p => p.At).HasColumnName("CreatedAt");
            });
            entity.OwnsOne(c => c.Modified, a =>
            {
                a.Property(p => p.UserId).HasColumnName("ModifiedByUserId");
                a.Property(p => p.At).HasColumnName("ModifiedAt");
            });

                entity.OwnsOne(c => c.Address, a =>
                {
                    a.Property(x => x.StreetAddress).HasColumnName("StreetAddress").IsRequired();
                    a.Property(x => x.City).HasColumnName("City").IsRequired();
                    a.Property(x => x.Province).HasColumnName("Province").IsRequired();
                    a.Property(x => x.Country).HasColumnName("Country").IsRequired();
                    a.Property(x => x.PostalCode).HasColumnName("PostalCode").IsRequired();
                    a.Property(x => x.PostOfficeBox).HasColumnName("PostOfficeBox");
                });
        });
    }

    private static void ConfigureDogEntity(ModelBuilder builder)
    {
        builder.Entity<Dog>(entity =>
        {
            entity.ToTable("Dogs");
            entity.HasOne(a => a.SecondaryBreed)
                .WithMany()
                .HasForeignKey(a => a.SecondaryBreedId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.OwnsOne(a => a.OriginCityInfo, oci =>
            {
                oci.Property(x => x.ComesFromAnotherCity).HasColumnName("ComesFromAnotherCity");
                oci.Property(x => x.HadJudgmentInThatCity).HasColumnName("HadJudgmentInThatCity");
            });

            entity.OwnsOne(a => a.DangerousDog, dd =>
            {
                dd.Property(p => p.IsDangerous).HasColumnName("IsDangerousDog");
                dd.Property(p => p.HasResponsibilityInsurance).HasColumnName("HasDangerousDogInsurance");
                dd.Property(p => p.Comment).HasColumnName("DangerousDogComment");
            });
        });
    }

    private static void ConfigureCatEntity(ModelBuilder builder)
    {
        builder.Entity<Cat>(entity =>
        {
            entity.ToTable("Cats");
        });
    }
}
