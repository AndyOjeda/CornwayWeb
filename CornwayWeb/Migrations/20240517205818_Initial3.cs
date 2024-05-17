using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CornwayWeb.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsumosGestionCultivos",
                columns: table => new
                {
                    IdInsumoGestionCultivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGestionCultivo = table.Column<int>(type: "int", nullable: false),
                    IdInsumoCultivo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dosis = table.Column<double>(type: "float", nullable: false),
                    Unidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsumosGestionCultivos", x => x.IdInsumoGestionCultivo);
                    table.ForeignKey(
                        name: "FK_InsumosGestionCultivos_GestionesCultivos_IdGestionCultivo",
                        column: x => x.IdGestionCultivo,
                        principalTable: "GestionesCultivos",
                        principalColumn: "IdGestionCultivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsumosGestionCultivos_InsumoCultivos_IdInsumoCultivo",
                        column: x => x.IdInsumoCultivo,
                        principalTable: "InsumoCultivos",
                        principalColumn: "IdInsumoCultivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsumosGestionCultivos_IdGestionCultivo",
                table: "InsumosGestionCultivos",
                column: "IdGestionCultivo");

            migrationBuilder.CreateIndex(
                name: "IX_InsumosGestionCultivos_IdInsumoCultivo",
                table: "InsumosGestionCultivos",
                column: "IdInsumoCultivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsumosGestionCultivos");
        }
    }
}
