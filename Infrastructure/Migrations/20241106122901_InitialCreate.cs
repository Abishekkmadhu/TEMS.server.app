using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredContactMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredTimeForContact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPreferences",
                columns: table => new
                {
                    CustomerPreferencesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreferredTourDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuidedTours = table.Column<bool>(type: "bit", nullable: false),
                    PackageInclusions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
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
                    OtherInformationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HowDidYouHearAboutUs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousCustomer = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
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
                    PackagePreferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BudgetRange = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccommodationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportationPreference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MealPreferences = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredActivities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
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
                    SpecialRequirementsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialRequests = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelInsurance = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
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
                    TravelDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelDestination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlexibleDates = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfAdults = table.Column<int>(type: "int", nullable: false),
                    NumberOfChildren = table.Column<int>(type: "int", nullable: false),
                    NumberOfInfants = table.Column<int>(type: "int", nullable: false),
                    TravelPurpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
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
