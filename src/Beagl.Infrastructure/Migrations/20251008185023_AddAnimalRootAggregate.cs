// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beagl.Infrastructure.Migrations;

/// <inheritdoc />
public partial class AddAnimalRootAggregate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
#pragma warning disable CA1062 // Validate arguments of public methods

        migrationBuilder.CreateTable(
            name: "Animals",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                ComesFromAnotherCity = table.Column<bool>(type: "boolean", nullable: true),
                HadJudgmentInThatCity = table.Column<bool>(type: "boolean", nullable: true),
                Name = table.Column<string>(type: "text", nullable: false),
                Species = table.Column<string>(type: "text", nullable: false),
                PrimaryBreed = table.Column<string>(type: "text", nullable: false),
                SecondaryBreed = table.Column<string>(type: "text", nullable: true),
                Color = table.Column<string>(type: "text", nullable: false),
                DistinctiveDescription = table.Column<string>(type: "text", nullable: true),
                Gender = table.Column<string>(type: "text", nullable: false),
                DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                PhotoBase64Png = table.Column<string>(type: "text", nullable: true),
                Microchip = table.Column<string>(type: "text", nullable: true),
                PermitExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                MedalNumber = table.Column<string>(type: "text", nullable: true),
                IsDangerousDog = table.Column<bool>(type: "boolean", nullable: true),
                HasDangerousDogInsurance = table.Column<bool>(type: "boolean", nullable: true),
                DangerousDogComment = table.Column<string>(type: "text", nullable: true),
                IsAnAssistanceDog = table.Column<bool>(type: "boolean", nullable: false),
                IsAnUnclawnedCat = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Animals", x => x.Id);
            });
#pragma warning restore CA1062 // Validate arguments of public methods


        migrationBuilder.CreateTable(
            name: "HealthRecords",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                IsSterilized = table.Column<bool>(type: "boolean", nullable: false),
                WeightValue = table.Column<decimal>(type: "numeric", nullable: true),
                WeightUnit = table.Column<string>(type: "text", nullable: true),
                RabiesVaccinationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                AnimalId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_HealthRecords", x => x.Id);
                table.ForeignKey(
                    name: "FK_HealthRecords_Animals_AnimalId",
                    column: x => x.AnimalId,
                    principalTable: "Animals",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_HealthRecords_AnimalId",
            table: "HealthRecords",
            column: "AnimalId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
#pragma warning disable CA1062 // Validate arguments of public methods
        migrationBuilder.DropTable(
            name: "HealthRecords");
#pragma warning restore CA1062 // Validate arguments of public methods

        migrationBuilder.DropTable(
            name: "Animals");
    }
}
