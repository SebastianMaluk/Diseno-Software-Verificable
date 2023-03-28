using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealState.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalizationRefToInscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Localizationid",
                table: "Inscription",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inscription_Localizationid",
                table: "Inscription",
                column: "Localizationid");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscription_Localization_Localizationid",
                table: "Inscription",
                column: "Localizationid",
                principalTable: "Localization",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscription_Localization_Localizationid",
                table: "Inscription");

            migrationBuilder.DropIndex(
                name: "IX_Inscription_Localizationid",
                table: "Inscription");

            migrationBuilder.DropColumn(
                name: "Localizationid",
                table: "Inscription");
        }
    }
}
