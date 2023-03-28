using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealState.Migrations
{
    /// <inheritdoc />
    public partial class AddCneRefToInscriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cneid",
                table: "Inscription",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inscription_Cneid",
                table: "Inscription",
                column: "Cneid");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscription_Cne_Cneid",
                table: "Inscription",
                column: "Cneid",
                principalTable: "Cne",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscription_Cne_Cneid",
                table: "Inscription");

            migrationBuilder.DropIndex(
                name: "IX_Inscription_Cneid",
                table: "Inscription");

            migrationBuilder.DropColumn(
                name: "Cneid",
                table: "Inscription");
        }
    }
}
