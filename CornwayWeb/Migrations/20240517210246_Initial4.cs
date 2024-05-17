using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CornwayWeb.Migrations
{
    /// <inheritdoc />
    public partial class Initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cultivos_IdUsuario",
                table: "Cultivos",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Cultivos_Usuarios_IdUsuario",
                table: "Cultivos",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cultivos_Usuarios_IdUsuario",
                table: "Cultivos");

            migrationBuilder.DropIndex(
                name: "IX_Cultivos_IdUsuario",
                table: "Cultivos");
        }
    }
}
