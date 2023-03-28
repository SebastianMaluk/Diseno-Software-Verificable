using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealState.Migrations
{
    /// <inheritdoc />
    public partial class AddEnajenante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enajenante",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rut = table.Column<string>(type: "TEXT", nullable: true),
                    Percentage_right = table.Column<int>(type: "INTEGER", nullable: false),
                    Check_percentage_not_credited = table.Column<int>(type: "INTEGER", nullable: false),
                    Inscriptionid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enajenante", x => x.id);
                    table.ForeignKey(
                        name: "FK_Enajenante_Inscription_Inscriptionid",
                        column: x => x.Inscriptionid,
                        principalTable: "Inscription",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enajenante_Inscriptionid",
                table: "Enajenante",
                column: "Inscriptionid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enajenante");
        }
    }
}
