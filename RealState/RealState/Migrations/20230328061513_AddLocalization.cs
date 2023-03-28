using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealState.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Localization",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    comuna = table.Column<string>(type: "TEXT", nullable: true),
                    manzana = table.Column<string>(type: "INTEGER", nullable: true),
                    predio = table.Column<string>(type: "INTEGER", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Localization", x => x.id); });
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Localization");

        }
    }
}
