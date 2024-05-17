using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CornwayWeb.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GestionesCultivos",
                columns: table => new
                {
                    IdGestionCultivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCultivo = table.Column<int>(type: "int", nullable: false),
                    IdTipoGestionCultivo = table.Column<int>(type: "int", nullable: false),
                    FechaGestion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GestionesCultivos", x => x.IdGestionCultivo);
                    table.ForeignKey(
                        name: "FK_GestionesCultivos_Cultivos_IdCultivo",
                        column: x => x.IdCultivo,
                        principalTable: "Cultivos",
                        principalColumn: "IdCultivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GestionesCultivos_TiposGestionCultivos_IdTipoGestionCultivo",
                        column: x => x.IdTipoGestionCultivo,
                        principalTable: "TiposGestionCultivos",
                        principalColumn: "IdTipoGestionCultivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GestionesCultivos_IdCultivo",
                table: "GestionesCultivos",
                column: "IdCultivo");

            migrationBuilder.CreateIndex(
                name: "IX_GestionesCultivos_IdTipoGestionCultivo",
                table: "GestionesCultivos",
                column: "IdTipoGestionCultivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GestionesCultivos");
        }
    }
}
