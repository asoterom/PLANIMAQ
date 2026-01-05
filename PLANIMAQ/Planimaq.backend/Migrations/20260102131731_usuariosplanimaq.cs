using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planimaq.backend.Migrations
{
    /// <inheritdoc />
    public partial class usuariosplanimaq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cities_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Personales");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "AspNetUsers",
                newName: "Cityid");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_CityId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_Cityid");

            migrationBuilder.AlterColumn<int>(
                name: "Cityid",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Brevete",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CaracteristicaA",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CaracteristicaB",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CaracteristicaC",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Especialidad",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nacionalidad",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Personal_Adjunto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaVigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaTermino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal_Adjunto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Personal_Adjunto_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personal_Adjunto_UserId1",
                table: "Personal_Adjunto",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cities_Cityid",
                table: "AspNetUsers",
                column: "Cityid",
                principalTable: "Cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cities_Cityid",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Personal_Adjunto");

            migrationBuilder.DropColumn(
                name: "Brevete",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CaracteristicaA",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CaracteristicaB",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CaracteristicaC",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Especialidad",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nacionalidad",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Cityid",
                table: "AspNetUsers",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_Cityid",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_CityId");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Personales",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    area_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cargo_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ccosto_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codccostotareo_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dfeba_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dfein_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dfena_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dhofin_pers = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dhoini_pers = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ncode_cargo = table.Column<int>(type: "int", nullable: false),
                    ncode_orar = table.Column<int>(type: "int", nullable: false),
                    ncond_pers = table.Column<int>(type: "int", nullable: false),
                    ncostohora_pers = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    nesta_pers = table.Column<int>(type: "int", nullable: false),
                    npimpo_pers = table.Column<int>(type: "int", nullable: false),
                    sapma_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sappa_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scamisatalla_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sdire_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sdni_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shofin_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shoini_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    slogo_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    smail_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    smailcorp_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    snomb_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    snomc_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spantalontalla_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stelefono_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stelefonocorp_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subigeo_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    szapatotalla_pers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vfirma_pers = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    vimagen_pers = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personales", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cities_CityId",
                table: "AspNetUsers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
