using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloLocal.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddCityAndPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Experiences_TourExperienceId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Guides_LocalGuideId",
                table: "Experiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guides",
                table: "Guides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experiences",
                table: "Experiences");

            migrationBuilder.RenameTable(
                name: "Guides",
                newName: "LocalGuide");

            migrationBuilder.RenameTable(
                name: "Experiences",
                newName: "TourExperience");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_LocalGuideId",
                table: "TourExperience",
                newName: "IX_TourExperience_LocalGuideId");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "LocalGuide",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "TourExperience",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocalGuide",
                table: "LocalGuide",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourExperience",
                table: "TourExperience",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_TourExperience_TourExperienceId",
                table: "Bookings",
                column: "TourExperienceId",
                principalTable: "TourExperience",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourExperience_LocalGuide_LocalGuideId",
                table: "TourExperience",
                column: "LocalGuideId",
                principalTable: "LocalGuide",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_TourExperience_TourExperienceId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TourExperience_LocalGuide_LocalGuideId",
                table: "TourExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourExperience",
                table: "TourExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocalGuide",
                table: "LocalGuide");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "TourExperience");

            migrationBuilder.DropColumn(
                name: "City",
                table: "LocalGuide");

            migrationBuilder.RenameTable(
                name: "TourExperience",
                newName: "Experiences");

            migrationBuilder.RenameTable(
                name: "LocalGuide",
                newName: "Guides");

            migrationBuilder.RenameIndex(
                name: "IX_TourExperience_LocalGuideId",
                table: "Experiences",
                newName: "IX_Experiences_LocalGuideId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experiences",
                table: "Experiences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guides",
                table: "Guides",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Experiences_TourExperienceId",
                table: "Bookings",
                column: "TourExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Guides_LocalGuideId",
                table: "Experiences",
                column: "LocalGuideId",
                principalTable: "Guides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
