using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CornwayWeb.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposCultivo",
                columns: table => new
                {
                    IdTipoCultivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCultivo", x => x.IdTipoCultivo);
                });

            migrationBuilder.CreateTable(
                name: "TiposGestionCultivos",
                columns: table => new
                {
                    IdTipoGestionCultivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposGestionCultivos", x => x.IdTipoGestionCultivo);
                });

            migrationBuilder.CreateTable(
                name: "TiposInsumoGestionCultivos",
                columns: table => new
                {
                    IdTipoInsumoGestionCultivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposInsumoGestionCultivos", x => x.IdTipoInsumoGestionCultivo);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuarios",
                columns: table => new
                {
                    IdTipoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuarios", x => x.IdTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "InsumoCultivos",
                columns: table => new
                {
                    IdInsumoCultivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoInsumoGestionCultivo = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsumoCultivos", x => x.IdInsumoCultivo);
                    table.ForeignKey(
                        name: "FK_InsumoCultivos_TiposInsumoGestionCultivos_IdTipoInsumoGestionCultivo",
                        column: x => x.IdTipoInsumoGestionCultivo,
                        principalTable: "TiposInsumoGestionCultivos",
                        principalColumn: "IdTipoInsumoGestionCultivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoUsuario = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoUsuarios_IdTipoUsuario",
                        column: x => x.IdTipoUsuario,
                        principalTable: "TipoUsuarios",
                        principalColumn: "IdTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsumosGestionCultivos",
                columns: table => new
                {
                    IdInsumoGestionCultivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        name: "FK_InsumosGestionCultivos_InsumoCultivos_IdInsumoCultivo",
                        column: x => x.IdInsumoCultivo,
                        principalTable: "InsumoCultivos",
                        principalColumn: "IdInsumoCultivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cultivos",
                columns: table => new
                {
                    IdCultivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdTipoCultivo = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultivos", x => x.IdCultivo);
                    table.ForeignKey(
                        name: "FK_Cultivos_TiposCultivo_IdTipoCultivo",
                        column: x => x.IdTipoCultivo,
                        principalTable: "TiposCultivo",
                        principalColumn: "IdTipoCultivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cultivos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cosechas",
                columns: table => new
                {
                    IdCosecha = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCultivo = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cosechas", x => x.IdCosecha);
                    table.ForeignKey(
                        name: "FK_Cosechas_Cultivos_IdCultivo",
                        column: x => x.IdCultivo,
                        principalTable: "Cultivos",
                        principalColumn: "IdCultivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GestionesCultivos",
                columns: table => new
                {
                    IdGestionCultivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCultivo = table.Column<int>(type: "int", nullable: false),
                    IdTipoGestionCultivo = table.Column<int>(type: "int", nullable: false),
                    IdInsumoGestionCultivo = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_GestionesCultivos_InsumosGestionCultivos_IdInsumoGestionCultivo",
                        column: x => x.IdInsumoGestionCultivo,
                        principalTable: "InsumosGestionCultivos",
                        principalColumn: "IdInsumoGestionCultivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GestionesCultivos_TiposGestionCultivos_IdTipoGestionCultivo",
                        column: x => x.IdTipoGestionCultivo,
                        principalTable: "TiposGestionCultivos",
                        principalColumn: "IdTipoGestionCultivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    IdPartida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCosecha = table.Column<int>(type: "int", nullable: false),
                    Monedas = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.IdPartida);
                    table.ForeignKey(
                        name: "FK_Partidas_Cosechas_IdCosecha",
                        column: x => x.IdCosecha,
                        principalTable: "Cosechas",
                        principalColumn: "IdCosecha",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cosechas_IdCultivo",
                table: "Cosechas",
                column: "IdCultivo");

            migrationBuilder.CreateIndex(
                name: "IX_Cultivos_IdTipoCultivo",
                table: "Cultivos",
                column: "IdTipoCultivo");

            migrationBuilder.CreateIndex(
                name: "IX_Cultivos_IdUsuario",
                table: "Cultivos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_GestionesCultivos_IdCultivo",
                table: "GestionesCultivos",
                column: "IdCultivo");

            migrationBuilder.CreateIndex(
                name: "IX_GestionesCultivos_IdInsumoGestionCultivo",
                table: "GestionesCultivos",
                column: "IdInsumoGestionCultivo");

            migrationBuilder.CreateIndex(
                name: "IX_GestionesCultivos_IdTipoGestionCultivo",
                table: "GestionesCultivos",
                column: "IdTipoGestionCultivo");

            migrationBuilder.CreateIndex(
                name: "IX_InsumoCultivos_IdTipoInsumoGestionCultivo",
                table: "InsumoCultivos",
                column: "IdTipoInsumoGestionCultivo");

            migrationBuilder.CreateIndex(
                name: "IX_InsumosGestionCultivos_IdInsumoCultivo",
                table: "InsumosGestionCultivos",
                column: "IdInsumoCultivo");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_IdCosecha",
                table: "Partidas",
                column: "IdCosecha");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdTipoUsuario",
                table: "Usuarios",
                column: "IdTipoUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GestionesCultivos");

            migrationBuilder.DropTable(
                name: "Partidas");

            migrationBuilder.DropTable(
                name: "InsumosGestionCultivos");

            migrationBuilder.DropTable(
                name: "TiposGestionCultivos");

            migrationBuilder.DropTable(
                name: "Cosechas");

            migrationBuilder.DropTable(
                name: "InsumoCultivos");

            migrationBuilder.DropTable(
                name: "Cultivos");

            migrationBuilder.DropTable(
                name: "TiposInsumoGestionCultivos");

            migrationBuilder.DropTable(
                name: "TiposCultivo");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TipoUsuarios");
        }
    }
}
