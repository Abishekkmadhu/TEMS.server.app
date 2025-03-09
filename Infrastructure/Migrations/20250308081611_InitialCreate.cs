using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    PreferredContactMethod = table.Column<string>(type: "text", nullable: true),
                    PreferredTimeForContact = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPreferences",
                columns: table => new
                {
                    CustomerPreferencesId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PreferredTourDuration = table.Column<string>(type: "text", nullable: true),
                    GuidedTours = table.Column<bool>(type: "boolean", nullable: false),
                    PackageInclusions = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPreferences", x => x.CustomerPreferencesId);
                    table.ForeignKey(
                        name: "FK_CustomerPreferences_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherInformation",
                columns: table => new
                {
                    OtherInformationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HowDidYouHearAboutUs = table.Column<string>(type: "text", nullable: true),
                    PreviousCustomer = table.Column<bool>(type: "boolean", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherInformation", x => x.OtherInformationId);
                    table.ForeignKey(
                        name: "FK_OtherInformation_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackagePreferences",
                columns: table => new
                {
                    PackagePreferenceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PackageType = table.Column<string>(type: "text", nullable: true),
                    BudgetRange = table.Column<decimal>(type: "numeric", nullable: true),
                    AccommodationType = table.Column<string>(type: "text", nullable: true),
                    TransportationPreference = table.Column<string>(type: "text", nullable: true),
                    MealPreferences = table.Column<string>(type: "text", nullable: true),
                    PreferredActivities = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagePreferences", x => x.PackagePreferenceId);
                    table.ForeignKey(
                        name: "FK_PackagePreferences_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialRequirements",
                columns: table => new
                {
                    SpecialRequirementsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SpecialRequests = table.Column<string>(type: "text", nullable: true),
                    TravelInsurance = table.Column<bool>(type: "boolean", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialRequirements", x => x.SpecialRequirementsId);
                    table.ForeignKey(
                        name: "FK_SpecialRequirements_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelDetails",
                columns: table => new
                {
                    TravelDetailsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TravelDestination = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FlexibleDates = table.Column<bool>(type: "boolean", nullable: false),
                    NumberOfAdults = table.Column<int>(type: "integer", nullable: true),
                    NumberOfChildren = table.Column<int>(type: "integer", nullable: true),
                    NumberOfInfants = table.Column<int>(type: "integer", nullable: true),
                    TravelPurpose = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelDetails", x => x.TravelDetailsId);
                    table.ForeignKey(
                        name: "FK_TravelDetails_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPreferences_CustomerId",
                table: "CustomerPreferences",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OtherInformation_CustomerId",
                table: "OtherInformation",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackagePreferences_CustomerId",
                table: "PackagePreferences",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialRequirements_CustomerId",
                table: "SpecialRequirements",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TravelDetails_CustomerId",
                table: "TravelDetails",
                column: "CustomerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerPreferences");

            migrationBuilder.DropTable(
                name: "OtherInformation");

            migrationBuilder.DropTable(
                name: "PackagePreferences");

            migrationBuilder.DropTable(
                name: "SpecialRequirements");

            migrationBuilder.DropTable(
                name: "TravelDetails");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
