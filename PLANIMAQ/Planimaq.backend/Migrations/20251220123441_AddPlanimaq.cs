using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planimaq.backend.Migrations
{
    /// <inheritdoc />
    public partial class AddPlanimaq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configuraciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MailData = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuraciones", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Maestros",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sValor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sIdGrupo = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    sGrupo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maestros", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MailData = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DateInitial = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Personales",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    snomb_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sappa_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sapma_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nesta_pers = table.Column<int>(type: "int", nullable: false),
                    sdni_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    snomc_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    slogo_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    npimpo_pers = table.Column<int>(type: "int", nullable: false),
                    smail_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ncode_cargo = table.Column<int>(type: "int", nullable: false),
                    dfein_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dfena_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ncode_orar = table.Column<int>(type: "int", nullable: false),
                    sdire_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vimagen_pers = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    dfeba_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ncond_pers = table.Column<int>(type: "int", nullable: false),
                    dhoini_pers = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dhofin_pers = table.Column<DateTime>(type: "datetime2", nullable: false),
                    shoini_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shofin_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vfirma_pers = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    cargo_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    area_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ccosto_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subigeo_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codccostotareo_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stelefono_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stelefonocorp_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scamisatalla_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spantalontalla_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    szapatotalla_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    smailcorp_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ncostohora_pers = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personales", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Configuraciones_Name",
                table: "Configuraciones",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuraciones");

            migrationBuilder.DropTable(
                name: "Maestros");

            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "Personales");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
