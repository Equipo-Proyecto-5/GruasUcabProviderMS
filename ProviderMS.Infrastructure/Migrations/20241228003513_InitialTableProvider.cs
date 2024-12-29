using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProviderMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialTableProvider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DenominacionComercial = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    RazonSocial = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    DireccionFisica = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TipoDocumentoIdentidad = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    NumeroDocumentoIdentidad = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Estatus = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grua",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    ProveedorId = table.Column<Guid>(type: "uuid", nullable: true),
                    Marca = table.Column<string>(type: "text", nullable: false),
                    Modelo = table.Column<string>(type: "text", nullable: false),
                    Año = table.Column<string>(type: "text", nullable: false),
                    Placa = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Estatus = table.Column<string>(type: "text", nullable: false),
                    Localizacion = table.Column<string>(type: "text", nullable: true),
                    Longitud = table.Column<double>(type: "double precision", nullable: true),
                    Latitud = table.Column<double>(type: "double precision", nullable: true),
                    Hora = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grua", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grua_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grua_ProveedorId",
                table: "Grua",
                column: "ProveedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grua");

            migrationBuilder.DropTable(
                name: "Proveedor");
        }
    }
}
