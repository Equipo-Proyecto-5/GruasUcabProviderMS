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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proveedor");
        }
    }
}
