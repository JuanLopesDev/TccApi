using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TccApi.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tccs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TituloTCC = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Autores = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Orientador = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataDeConclusao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tccs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tccs");
        }
    }
}
